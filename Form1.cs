using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace responsi
{
    public partial class Form1 : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=informatika;Database=responsiresponsi";
        private int selectedId = 0;

        private List<Developer> listDevs = new List<Developer>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProyekCombo();
            LoadDataDeveloper();

            cbStatus.Items.Clear();
            cbStatus.Items.Add("Full Time");
            cbStatus.Items.Add("Freelance");
            cbStatus.SelectedIndex = -1;
        }
        private void LoadDataDeveloper()
        {
            listDevs.Clear(); 
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = @"SELECT d.*, p.nama_proyek 
                                   FROM developer d 
                                   JOIN proyek p ON d.id_proyek = p.id_proyek 
                                   ORDER BY d.id_dev ASC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader["status_kontrak"].ToString();
                            Developer dev;

                            if (status == "Full Time") dev = new FullTimeDeveloper();
                            else dev = new FreelanceDeveloper();

                            // Isi data dari DB
                            dev.Id = Convert.ToInt32(reader["id_dev"]);
                            dev.IdProyek = Convert.ToInt32(reader["id_proyek"]);
                            dev.NamaProyek = reader["nama_proyek"].ToString();
                            dev.Nama = reader["nama_dev"].ToString();
                            dev.Fitur = Convert.ToInt32(reader["fitur_selesai"]);
                            dev.Bug = Convert.ToInt32(reader["jumlah_bug"]);

                            listDevs.Add(dev);
                        }
                    }
                }
                var displayList = new List<object>();
                foreach (var d in listDevs)
                {
                    displayList.Add(new
                    {
                        ID = d.Id,
                        Nama = d.Nama,
                        Proyek = d.NamaProyek,
                        Status = d.Status,
                        Fitur = d.Fitur,
                        Bug = d.Bug,
                        Skor = d.HitungSkor().ToString("0.##"), 
                        TotalGaji = d.HitungGaji().ToString("N0") 
                    });
                }
                dgvData.DataSource = null;
                dgvData.DataSource = displayList;

                dgvData.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load: " + ex.Message);
            }
        }
        private bool IsBudgetSafe(int idProyek, decimal gajiDeveloperBaru, int ignoreDevId = -1)
        {
            decimal totalGajiExisting = 0;
            decimal budgetProyek = 0;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sqlBudget = "SELECT budget FROM proyek WHERE id_proyek = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlBudget, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idProyek);
                    object result = cmd.ExecuteScalar();
                    if (result != null) budgetProyek = Convert.ToDecimal(result);
                }
                foreach (var dev in listDevs)
                {
                    // Hanya hitung developer di proyek yang sama, KECUALI developer yang sedang diedit
                    if (dev.IdProyek == idProyek && dev.Id != ignoreDevId)
                    {
                        totalGajiExisting += dev.HitungGaji();
                    }
                }
            }
            decimal totalPerkiraan = totalGajiExisting + gajiDeveloperBaru;

            if (totalPerkiraan > budgetProyek)
            {
                MessageBox.Show($"GAGAL! Project Overbudget.\nBudget: {budgetProyek:N0}\nTotal Gaji (termasuk baru): {totalPerkiraan:N0}\nSelisih: {(totalPerkiraan - budgetProyek):N0}");
                return false;
            }
            return true;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cbProyek.SelectedIndex == -1 || cbStatus.SelectedIndex == -1) return;

            Developer tempDev;
            if (cbStatus.Text == "Full Time") tempDev = new FullTimeDeveloper();
            else tempDev = new FreelanceDeveloper();

            tempDev.Fitur = int.Parse(txtFitur.Text);
            tempDev.Bug = int.Parse(txtBug.Text);

            decimal prediksiGaji = tempDev.HitungGaji();
            int idProyek = Convert.ToInt32(cbProyek.SelectedValue);

            if (!IsBudgetSafe(idProyek, prediksiGaji)) return;

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT insert_developer(@id_p, @nama, @status, @fitur, @bug)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_p", idProyek);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@status", cbStatus.Text);
                        cmd.Parameters.AddWithValue("@fitur", tempDev.Fitur);
                        cmd.Parameters.AddWithValue("@bug", tempDev.Bug);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDataDeveloper(); 
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Insert: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) return;

            Developer tempDev;
            if (cbStatus.Text == "Full Time") tempDev = new FullTimeDeveloper();
            else tempDev = new FreelanceDeveloper();

            tempDev.Fitur = int.Parse(txtFitur.Text);
            tempDev.Bug = int.Parse(txtBug.Text);

            int idProyek = Convert.ToInt32(cbProyek.SelectedValue);

            if (!IsBudgetSafe(idProyek, tempDev.HitungGaji(), selectedId)) return;

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT update_developer(@id, @id_p, @nama, @status, @fitur, @bug)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.Parameters.AddWithValue("@id_p", idProyek);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@status", cbStatus.Text);
                        cmd.Parameters.AddWithValue("@fitur", tempDev.Fitur);
                        cmd.Parameters.AddWithValue("@bug", tempDev.Bug);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDataDeveloper();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update: " + ex.Message);
            }
        }
        private void LoadProyekCombo()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT id_proyek, nama_proyek FROM proyek", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbProyek.DataSource = dt;
                cbProyek.DisplayMember = "nama_proyek";
                cbProyek.ValueMember = "id_proyek";
            }
        }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["ID"].Value);
                Developer dev = listDevs.Find(d => d.Id == id);

                selectedId = dev.Id;
                txtNama.Text = dev.Nama;
                cbProyek.SelectedValue = dev.IdProyek;
                cbStatus.Text = dev.Status;
                txtFitur.Text = dev.Fitur.ToString();
                txtBug.Text = dev.Bug.ToString();
            }
        }
        private void ClearForm()
        {
            selectedId = 0;
            txtNama.Clear(); txtFitur.Clear(); txtBug.Clear();
            cbProyek.SelectedIndex = -1; cbStatus.SelectedIndex = -1;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) return;
            if (MessageBox.Show("Hapus?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT delete_developer(@id)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDataDeveloper();
                ClearForm();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label8_Click(object sender, EventArgs e)
        {
        }
    }
}