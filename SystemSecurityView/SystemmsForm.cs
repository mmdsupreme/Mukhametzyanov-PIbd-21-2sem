﻿using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemSecurityView
{
    public partial class SystemmsForm : Form
    {
        public SystemmsForm()
        {
            InitializeComponent();
        }

        private void SystemmsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<SystemmViewModel> list = Task.Run(() => APIClient.GetRequestData<List<SystemmViewModel>>("api/Systemm/GetList")).Result;
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new SystemmForm();
            form.ShowDialog();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new SystemmForm();
                form.ID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.ShowDialog();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    Task task = Task.Run(() => APIClient.PostRequestData("api/Systemm/DelElement", new CustomerBindModel { ID = id }));
                    task.ContinueWith((prevTask) => MessageBox.Show("Запись удалена. Обновите список", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information),
                    TaskContinuationOptions.OnlyOnRanToCompletion);
                    task.ContinueWith((prevTask) =>
                    {
                        var ex = (Exception)prevTask.Exception;
                        while (ex.InnerException != null)
                        {
                            ex = ex.InnerException;
                        }
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }, TaskContinuationOptions.OnlyOnFaulted);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
