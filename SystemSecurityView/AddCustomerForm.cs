﻿using SystemSecurityService.Interfaces;
using SystemSecurityService.ViewModel;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace SystemSecurityView
{
    public partial class AddCustomerForm : Form
    {
        [Dependency]
        public new IUnityContainer container { get; set; }
        private int? id;
        public int ID { set { id = value; } }
        private readonly ICustomer service;

        public AddCustomerForm(ICustomer service)
        {
            InitializeComponent();
            this.service = service;
        }

        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CustomerViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        FIO.Text = view.CustomerFIO;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FIO.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new SystemSecurityService.BindingModels.CustomerBindModel
                    {
                        ID = id.Value,
                        CustomerFIO = FIO.Text
                    });
                }
                else
                {
                    service.AddElement(new SystemSecurityService.BindingModels.CustomerBindModel
                    {
                        CustomerFIO = FIO.Text
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
