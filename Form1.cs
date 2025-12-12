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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProyekCombo();
            LoadDataDeveloper();

            cbStatus.Items.Add("Full Time");
            cbStatus.Items.Add("Freelance");
            cbStatus.SelectedIndex = -1;
        }

        private void LoadDataDeveloper()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    // Query JOIN sesuai permintaan soal (Menampilkan Nama Proyek, bukan ID)
                    string sql = @"
                        SELECT 
                            d.id_dev, 
                            d.nama_dev, 
                            p.nama_proyek, 
                            d.status_kontrak, 
                            d.fitur_selesai, 
                            d.jumlah_bug,
                            d.id_proyek -- Hidden column for logic
                        FROM developer d
                        JOIN proyek p ON d.id_proyek = p.id_proyek
                        ORDER BY d.id_dev ASC";

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvData.DataSource = dt;

                    // Sembunyikan kolom ID agar rapi (Opsional)
                    dgvData.Columns["id_dev"].Visible = false;
                    dgvData.Columns["id_proyek"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Data: " + ex.Message);
            }
        }

        private void LoadProyekCombo()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT id_proyek, nama_proyek FROM proyek";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbProyek.DataSource = dt;
                    cbProyek.DisplayMember = "nama_proyek";
                    cbProyek.ValueMember = "id_proyek";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Combo: " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Menggunakan Objek OOP sebelum insert
                Developer dev = new Developer();
                dev.Nama = txtNama.Text;
                dev.IdProyek = Convert.ToInt32(cbProyek.SelectedValue);
                dev.FiturSelesai = int.Parse(txtFitur.Text);
                dev.JumlahBug = int.Parse(txtBug.Text);
                string status = cbStatus.Text;

                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = "INSERT INTO developer (id_proyek, nama_dev, status_kontrak, fitur_selesai, jumlah_bug) VALUES (@id_p, @nama, @status, @fitur, @bug)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_p", dev.IdProyek);
                        cmd.Parameters.AddWithValue("@nama", dev.Nama);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@fitur", dev.FiturSelesai);
                        cmd.Parameters.AddWithValue("@bug", dev.JumlahBug);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil ditambahkan!");
                LoadDataDeveloper();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Insert: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) { MessageBox.Show("Pilih data tabel dulu!"); return; }

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string sql = "UPDATE developer SET id_proyek=@id_p, nama_dev=@nama, status_kontrak=@status, fitur_selesai=@fitur, jumlah_bug=@bug WHERE id_dev=@id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_p", Convert.ToInt32(cbProyek.SelectedValue));
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                        cmd.Parameters.AddWithValue("@status", cbStatus.Text);
                        cmd.Parameters.AddWithValue("@fitur", int.Parse(txtFitur.Text));
                        cmd.Parameters.AddWithValue("@bug", int.Parse(txtBug.Text));
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil diupdate!");
                LoadDataDeveloper();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Update: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) { MessageBox.Show("Pilih data tabel dulu!"); return; }

            if (MessageBox.Show("Yakin hapus?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();
                        string sql = "DELETE FROM developer WHERE id_dev=@id";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadDataDeveloper();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal Delete: " + ex.Message);
                }
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];

                selectedId = Convert.ToInt32(row.Cells["id_dev"].Value);
                txtNama.Text = row.Cells["nama_dev"].Value.ToString();
                cbStatus.Text = row.Cells["status_kontrak"].Value.ToString();
                txtFitur.Text = row.Cells["fitur_selesai"].Value.ToString();
                txtBug.Text = row.Cells["jumlah_bug"].Value.ToString();

                // Set ComboBox Proyek berdasarkan ID (kolom hidden)
                cbProyek.SelectedValue = row.Cells["id_proyek"].Value;
            }
        }

        private void ClearForm()
        {
            selectedId = 0;
            txtNama.Clear();
            txtFitur.Clear();
            txtBug.Clear();
            cbProyek.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}