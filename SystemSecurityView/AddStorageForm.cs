﻿using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemSecurityView
{
    public partial class AddStorageForm : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public AddStorageForm()
        {
            InitializeComponent();
        }

        private void AddStorageForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var response = APIClient.GetRequest("api/Storage/Get/" + id.Value);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var stock = APIClient.GetElement<StorageViewModel>(response);
                        textBoxName.Text = stock.StorageName;
                        dataGridView.DataSource = stock.StorageElements;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        throw new Exception(APIClient.GetError(response));
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
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (id.HasValue)
                {
                    response = APIClient.PostRequest("api/Storage/UpdElement", new StorageBindModel
                    {
                        ID = id.Value,
                        StorageName = textBoxName.Text
                    });
                }
                else
                {
                    response = APIClient.PostRequest("api/Storage/UpdElement", new StorageBindModel
                    {
                        StorageName = textBoxName.Text
                    });
                }
                if (response.Result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    throw new Exception(APIClient.GetError(response));
                }
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
