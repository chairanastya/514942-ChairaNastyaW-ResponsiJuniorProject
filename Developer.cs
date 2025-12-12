using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace responsi
{
    public class Developer
    {
        // Encapsulation: Field private diakses lewat Property public
        private int _id;
        private string _nama;
        private int _fitur;
        private int _bug;

        public int Id { get => _id; set => _id = value; }
        public string Nama { get => _nama; set => _nama = value; }
        public int IdProyek { get; set; }
        public int FiturSelesai { get => _fitur; set => _fitur = value; }
        public int JumlahBug { get => _bug; set => _bug = value; }

        // Virtual method untuk bisa di-override (konsep Polymorphism sederhana)
        public virtual string GetRoleDescription()
        {
            return "Developer Umum";
        }
    }

    // Derived Class (Anak) - Contoh Inheritance
    public class FullTimeDeveloper : Developer
    {
        public string Status { get; } = "Full Time";

        public override string GetRoleDescription()
        {
            return "Karyawan Tetap";
        }
    }

    // Derived Class (Anak) - Contoh Inheritance
    public class FreelanceDeveloper : Developer
    {
        public string Status { get; } = "Freelance";

        public override string GetRoleDescription()
        {
            return "Pekerja Lepas";
        }
    }
}