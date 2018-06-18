﻿using SystemSecurityService.BindingModels;
using SystemSecurityService.Interfaces;
using SystemSecurityService.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace SystemSecurityView
{
    public partial class SystemmForm : Form
    {
        [Dependency]
        public new IUnityContainer container { set; get; }
        public int ID { set { id = value; } }
        private int? id;
        private readonly ISystemm service;
        private List<ElementRequirementsViewModel> productElems;

        public SystemmForm(ISystemm service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SystemmViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        Name.Text = view.SystemmName;
                        Price.Text = view.Price.ToString();
                        productElems = view.ElementRequirements;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                productElems = new List<ElementRequirementsViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (productElems != null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = productElems;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var form = container.Resolve<AddElementForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.SystemmID = id.Value;
                    }
                    productElems.Add(form.Model);
                }
                LoadData();
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var form = container.Resolve<AddElementForm>();
                form.Model = productElems[dataGridView1.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    productElems[dataGridView1.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        productElems.RemoveAt(dataGridView1.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(PriceTextBox.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (productElems == null || productElems.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<ElementRequirementsBindModel> productComponentBM = new List<ElementRequirementsBindModel>();
                for (int i = 0; i < productElems.Count; ++i)
                {
                    productComponentBM.Add(new ElementRequirementsBindModel
                    {
                        ID = productElems[i].ID,
                        SystemmID = productElems[i].SystemmID,
                        ElementID = productElems[i].ElementID,
                        Count = productElems[i].Count
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new SystemmBindModel
                    {
                        ID = id.Value,
                        SystemmName = NameTextBox.Text,
                        Price = Convert.ToInt32(PriceTextBox.Text),
                        ElementRequirements = productComponentBM
                    });
                }
                else
                {
                    service.AddElement(new SystemmBindModel
                    {
                        SystemmName = NameTextBox.Text,
                        Price = Convert.ToInt32(PriceTextBox.Text),
                        ElementRequirements = productComponentBM
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
