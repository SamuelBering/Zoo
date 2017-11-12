using System;
using System.Windows.Forms;
using Zoo.BL;
using System.Linq;
using System.Collections.Generic;
using Zoo.ViewModels;
using Zoo.UI;
using System.ComponentModel;

namespace Zoo
{
    public partial class ZooForm : Form
    {
        IZoo zoo;

        public ZooForm(IZoo zoo)
        {
            this.zoo = zoo;
            InitializeComponent();
            LoadAllEnvironments();
            LoadAllAnimals();
            //zoo.RemoveAnimal(new Animal { Id = 28 });

            //zoo.AddOrUpdateVeterinaryReservation(new VeterinaryReservation { AnimalId = 28, DiagnosisId = 1 });
            //zoo.GetVeterinaryReservations(28);
            //zoo.SeedDataBase();
        }

        private void InitializeResultDataGridColumns()
        {
            resultDataGridView.Columns["Type"].ReadOnly = true;
            resultDataGridView.Columns["Environment"].ReadOnly = true;
            resultDataGridView.Columns["Parent1"].ReadOnly = true;
            resultDataGridView.Columns["Parent2"].ReadOnly = true;
            resultDataGridView.Columns["Id"].Visible = false;
            resultDataGridView.Columns["Parent1Id"].Visible = false;
            resultDataGridView.Columns["Parent2Id"].Visible = false;
        }

        private void LoadAllAnimals()
        {
            resultDataGridView.DataSource = zoo.GetAllAnimals();
            InitializeResultDataGridColumns();
        }

        private void LoadAllEnvironments()
        {
            environmentComboBox.DataSource = zoo.GetAllEnvironments();
            environmentComboBox.DisplayMember = "Name";
            environmentComboBox.ValueMember = "Name";
        }

        private void UpdateDataGridViewWithFilterResults()
        {
            string environment = (string)environmentComboBox.SelectedValue;
            string type = typeComboBox.Text;
            string spieces = spiecesTextBox.Text;
            resultDataGridView.DataSource = zoo.GetAnimals(environment, type, spieces);
            InitializeResultDataGridColumns();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewWithFilterResults();
        }

        private void AddNewAnimalFromNameWeightSpiecesOrCountry(DataGridView dataGridView,
                            DataGridViewCellEventArgs e,
                            string columnName, object newValue)
        {
            Animal animal = null;

            switch (columnName)
            {
                case "name":
                    animal = new Animal
                    {
                        Name = (string)newValue
                    };
                    dataGridView[0, e.RowIndex].Value = zoo.AddOrUpdateAnimal(animal);
                    break;

                case "weight":
                    animal = new Animal
                    {
                        Name = "Ny",
                        Weight = (int)newValue
                    };
                    dataGridView[0, e.RowIndex].Value = zoo.AddOrUpdateAnimal(animal);
                    dataGridView.Rows[e.RowIndex].Cells["Name"].Value = animal.Name;
                    break;
                case "spieces":
                    animal = new Animal
                    {
                        Name = "Ny",
                        Spieces = (string)newValue
                    };
                    dataGridView[0, e.RowIndex].Value = zoo.AddOrUpdateAnimal(animal);
                    dataGridView.Rows[e.RowIndex].Cells["Name"].Value = animal.Name;
                    break;
                case "countryoforigin":
                    animal = new Animal
                    {
                        Name = "Ny",
                        CountryOfOrigin = (string)newValue
                    };
                    dataGridView[0, e.RowIndex].Value = zoo.AddOrUpdateAnimal(animal);
                    dataGridView.Rows[e.RowIndex].Cells["Name"].Value = animal.Name;
                    break;
            }
        }

        private void resultDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            var newValue = dataGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = dataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();

            if ((int)dataGridView[0, e.RowIndex].Value == 0)
            {
                if (columnName == "name" || columnName == "weight" || columnName == "spieces" ||
                    columnName == "countryoforigin")
                    AddNewAnimalFromNameWeightSpiecesOrCountry(dataGridView, e, columnName, newValue);
            }
            else
            {
                if (columnName == "name" || columnName == "weight" || columnName == "spieces" ||
                    columnName == "countryoforigin")
                    UpdateAnimalFromNameWeightSpiecesOrCountry(dataGridView, e, columnName, newValue);
            }

        }

        private void UpdateAnimalFromNameWeightSpiecesOrCountry(DataGridView dataGridView, DataGridViewCellEventArgs e, string columnName, object newValue)
        {
            zoo.AddOrUpdateAnimal((Animal)dataGridView.Rows[e.RowIndex].DataBoundItem);
        }

        private void GetTypeAndUpdateAnimal(DataGridView dataGridView, DataGridViewCellEventArgs e,
                                            Animal animal)
        {
            DropDownListForm dropDownListForm = new DropDownListForm();

            foreach (var item in this.typeComboBox.Items)
                dropDownListForm.DropDownComboBox.Items.Add(item);

            dropDownListForm.DropDownComboBox.Text = (string)dataGridView[e.ColumnIndex, e.RowIndex].Value;

            if (dropDownListForm.ShowDialog(this) == DialogResult.OK)
            {
                var selectedItem = dropDownListForm.DropDownComboBox.SelectedItem;
                animal.Type = selectedItem != null ? (string)selectedItem : null;
            }

            dropDownListForm.Dispose();
        }

        private void GetEnvironmentAndUpdateAnimal(DataGridView dataGridView, DataGridViewCellEventArgs e,
                                         Animal animal)
        {
            DropDownListForm dropDownListForm = new DropDownListForm();

            foreach (var item in this.environmentComboBox.Items)
                dropDownListForm.DropDownComboBox.Items.Add(item);

            dropDownListForm.DropDownComboBox.DisplayMember = "Name";
            dropDownListForm.DropDownComboBox.ValueMember = "Name";
            dropDownListForm.DropDownComboBox.Text = (string)dataGridView[e.ColumnIndex, e.RowIndex].Value;
            if (dropDownListForm.ShowDialog(this) == DialogResult.OK)
            {
                ViewModels.Environment selectedEnvironment =
                    (ViewModels.Environment)dropDownListForm.DropDownComboBox.SelectedItem;

                animal.Environment = (selectedEnvironment != null && selectedEnvironment.Name != "") ? selectedEnvironment.Name : null;
            }

            dropDownListForm.Dispose();
        }

        private void GetParent1AndUpdateAnimal(DataGridView dataGridView, DataGridViewCellEventArgs e,
                                         Animal animal)
        {
            DropDownListForm dropDownListForm = new DropDownListForm();

            BindingList<Animal> animals = zoo.GetAllAnimals();

            animals = new BindingList<Animal>(animals.Where(a => a.Id != animal.Id).ToList());

            animals.Insert(0, new ViewModels.Animal { Id = -1, Name = "" });

            dropDownListForm.DropDownComboBox.DataSource = animals;
            dropDownListForm.DropDownComboBox.DisplayMember = "Name";
            dropDownListForm.DropDownComboBox.ValueMember = "Id";

            for (int i = 0; i < dropDownListForm.DropDownComboBox.Items.Count; i++)
                if (((ViewModels.Animal)dropDownListForm.DropDownComboBox.Items[i]).Id == animal.Parent1Id)
                    dropDownListForm.DropDownComboBox.SelectedIndex = i;

            if (dropDownListForm.ShowDialog(this) == DialogResult.OK)
            {
                ViewModels.Animal selectedAnimal =
                    (ViewModels.Animal)dropDownListForm.DropDownComboBox.SelectedItem;
                if (selectedAnimal != null)
                {
                    if (selectedAnimal.Id == -1)
                    {
                        animal.Parent1 = null;
                        animal.Parent1Id = null;
                    }
                    else
                    {
                        animal.Parent1 = selectedAnimal.Name;
                        animal.Parent1Id = selectedAnimal.Id;
                    }
                }
            }

            dropDownListForm.Dispose();
        }

        private void GetParent2AndUpdateAnimal(DataGridView dataGridView, DataGridViewCellEventArgs e,
                                        Animal animal)
        {
            DropDownListForm dropDownListForm = new DropDownListForm();

            BindingList<Animal> animals = zoo.GetAllAnimals();

            animals = new BindingList<Animal>(animals.Where(a => a.Id != animal.Id).ToList());
            animals.Insert(0, new ViewModels.Animal { Id = -1, Name = "" });

            dropDownListForm.DropDownComboBox.DataSource = animals;
            dropDownListForm.DropDownComboBox.DisplayMember = "Name";
            dropDownListForm.DropDownComboBox.ValueMember = "Id";

            for (int i = 0; i < dropDownListForm.DropDownComboBox.Items.Count; i++)
                if (((ViewModels.Animal)dropDownListForm.DropDownComboBox.Items[i]).Id == animal.Parent2Id)
                    dropDownListForm.DropDownComboBox.SelectedIndex = i;

            if (dropDownListForm.ShowDialog(this) == DialogResult.OK)
            {
                ViewModels.Animal selectedAnimal =
                    (ViewModels.Animal)dropDownListForm.DropDownComboBox.SelectedItem;

                if (selectedAnimal != null)
                {
                    if (selectedAnimal.Id == -1)
                    {
                        animal.Parent2 = null;
                        animal.Parent2Id = null;
                    }
                    else
                    {
                        animal.Parent2 = selectedAnimal.Name;
                        animal.Parent2Id = selectedAnimal.Id;
                    }
                }
            }

            dropDownListForm.Dispose();
        }

        private void resultDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            DataGridView dataGridView = (DataGridView)sender;

            var columnName = dataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();

            if (columnName == "type" || columnName == "environment" ||
                columnName == "parent1" || columnName == "parent2")
            {
                if (e.RowIndex == dataGridView.Rows.Count - 1)
                {

                    BindingList<Animal> animals = (BindingList<Animal>)dataGridView.DataSource;
                    dataGridView.DataSource = null;
                    animals.Add(new Animal { Name = "Ny" });
                    dataGridView.DataSource = animals;
                    InitializeResultDataGridColumns();
                    dataGridView.ClearSelection();
                    dataGridView[e.ColumnIndex, e.RowIndex].Selected = true;
                }

                Animal animal = (Animal)dataGridView.Rows[e.RowIndex].DataBoundItem;

                if (columnName == "type")
                    GetTypeAndUpdateAnimal(dataGridView, e, animal);
                else if (columnName == "environment")
                    GetEnvironmentAndUpdateAnimal(dataGridView, e, animal);
                else if (columnName == "parent1")
                    GetParent1AndUpdateAnimal(dataGridView, e, animal);
                else if (columnName == "parent2")
                    GetParent2AndUpdateAnimal(dataGridView, e, animal);

                dataGridView[0, e.RowIndex].Value = zoo.AddOrUpdateAnimal(animal);
            }

        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (resultDataGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < resultDataGridView.Rows.Count; i++)
                {
                    if (resultDataGridView.Rows[i].Selected)
                    {

                        Animal animal = (Animal)resultDataGridView.Rows[i].DataBoundItem;
                        if (animal != null)
                        {
                            if (animal.Parent1Id != null || animal.Parent2Id != null)
                                MessageBox.Show($"Unable to remove animal: \"{animal.Name}\" on row: {i + 1}. You must remove all parent connections for this animal before removal.", "Animal has parent connections!");
                            else
                                zoo.RemoveAnimal(animal);
                        }
                    }
                }
                UpdateDataGridViewWithFilterResults();
            }
        }

        private void veterinaryReservationsButton_Click(object sender, EventArgs e)
        {
            if (resultDataGridView.SelectedRows.Count == 1)
            {
                int animalId = ((Animal)resultDataGridView.SelectedRows[0].DataBoundItem).Id;
                veterinaryReservationsForm veterinaryReservationsForm = new veterinaryReservationsForm(animalId, zoo);
                veterinaryReservationsForm.Show();
            }

        }
    }
}
