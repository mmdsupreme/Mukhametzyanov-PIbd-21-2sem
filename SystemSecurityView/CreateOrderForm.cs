using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SystemSecurityView
{
    public partial class CreateOrderForm : Form
    {
        public CreateOrderForm()
        {
            InitializeComponent();
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                var responseC = APIClient.GetRequest("api/Customer/GetList");
                if (responseC.Result.IsSuccessStatusCode)
                {
                    List<CustomerViewModel> list = APIClient.GetElement<List<CustomerViewModel>>(responseC);
                    if (list != null)
                    {
                        CustomerCB.DisplayMember = "CustomerFIO";
                        CustomerCB.ValueMember = "ID";
                        CustomerCB.DataSource = list;
                        CustomerCB.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APIClient.GetError(responseC));
                }
                var responseP = APIClient.GetRequest("api/Systemm/GetList");
                if (responseP.Result.IsSuccessStatusCode)
                {
                    List<SystemmViewModel> list = APIClient.GetElement<List<SystemmViewModel>>(responseP);
                    if (list != null)
                    {
                        SystemmCB.DisplayMember = "SystemmName";
                        SystemmCB.ValueMember = "ID";
                        SystemmCB.DataSource = list;
                        SystemmCB.SelectedItem = null;
                    }
                }
                else
                {
                    throw new Exception(APIClient.GetError(responseP));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Calculate()
        {
            if (SystemmCB.SelectedValue != null && !string.IsNullOrEmpty(CountTB.Text))
            {
                try
                {
                    int id = Convert.ToInt32(SystemmCB.SelectedValue);
                    var responseP = APIClient.GetRequest("api/Systemm/Get/" + id);
                    if (responseP.Result.IsSuccessStatusCode)
                    {
                        SystemmViewModel product = APIClient.GetElement<SystemmViewModel>(responseP);
                        int count = Convert.ToInt32(CountTB.Text);
                        SumTB.Text = (count * (int)product.Price).ToString();
                    }
                    else
                    {
                        throw new Exception(APIClient.GetError(responseP));
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
            if (string.IsNullOrEmpty(CountTB.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CustomerCB.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SystemmCB.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var response = APIClient.PostRequest("api/Main/CreateOrder", new OrderBindModel
                {
                    CustomerID = Convert.ToInt32(CustomerCB.SelectedValue),
                    SystemmID = Convert.ToInt32(SystemmCB.SelectedValue),
                    Count = Convert.ToInt32(CountTB.Text),
                    Sum = Convert.ToInt32(SumTB.Text)
                }); if (response.Result.IsSuccessStatusCode)
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

        private void CountTB_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void SystemmCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
