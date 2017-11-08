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
        }

        private void LoadAllAnimals()
        {
            resultDataGridView.DataSource = zoo.GetAllAnimals();
        }

        private void LoadAllEnvironments()
        {
            environmentComboBox.DataSource = zoo.GetAllEnvironments();
            environmentComboBox.DisplayMember = "Name";
            environmentComboBox.ValueMember = "Name";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string environment = (string)environmentComboBox.SelectedValue;
            string type = typeComboBox.Text;
            string spieces = spiecesTextBox.Text;
            resultDataGridView.DataSource = zoo.GetAnimals(environment, type, spieces);
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
                animal.Type = (string)selectedItem;
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

                animal.Environment = selectedEnvironment.Name;
            }

            dropDownListForm.Dispose();
        }

        private void resultDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
                    dataGridView.ClearSelection();
                    dataGridView[e.ColumnIndex, e.RowIndex].Selected = true;
                }

                Animal animal = (Animal)dataGridView.Rows[e.RowIndex].DataBoundItem;

                if (columnName == "type")
                    GetTypeAndUpdateAnimal(dataGridView, e, animal);
                else if (columnName == "environment")
                    GetEnvironmentAndUpdateAnimal(dataGridView, e, animal);



            }

        }
    }
}
