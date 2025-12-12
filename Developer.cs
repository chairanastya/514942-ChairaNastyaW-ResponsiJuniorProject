using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace responsi
{
    // 1. ABSTRACTION: Base class abstrak
    public abstract class Developer
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int IdProyek { get; set; }
        public string NamaProyek { get; set; } // Untuk display
        public string Status { get; set; }
        public int Fitur { get; set; }
        public int Bug { get; set; }

        // Abstract Methods (Polymorphism) - Wajib di-override anak kelas
        public abstract double HitungSkor();
        public abstract decimal HitungGaji();
    }

    // 2. INHERITANCE & POLYMORPHISM: Karyawan Full Time
    public class FullTimeDeveloper : Developer
    {
        public FullTimeDeveloper() { Status = "Full Time"; }

        public override double HitungSkor()
        {
            // Rumus: 10 * Fitur - 5 * Bug
            double skor = (10 * Fitur) - (5 * Bug);
            return skor < 0 ? 0 : skor; // Skor tidak boleh negatif
        }

        public override decimal HitungGaji()
        {
            // Rumus: Gaji Pokok (5jt) + (Skor * 20.000)
            decimal gajiPokok = 5000000;
            decimal bonus = (decimal)HitungSkor() * 20000;
            return gajiPokok + bonus;
        }
    }

    // 3. INHERITANCE & POLYMORPHISM: Karyawan Freelance
    public class FreelanceDeveloper : Developer
    {
        public FreelanceDeveloper() { Status = "Freelance"; }

        public override double HitungSkor()
        {
            // Rumus: 100 * (1 - (2*Bug / 3*Fitur))
            if (Fitur == 0) return 0; // Hindari pembagian nol

            double ratio = (2.0 * Bug) / (3.0 * Fitur);
            double skor = 100 * (1 - ratio);

            return skor < 0 ? 0 : skor; // Skor tidak mungkin kurang dari 0
        }

        public override decimal HitungGaji()
        {
            double skor = HitungSkor();
            decimal tarifPerFitur;

            if (skor >= 80) tarifPerFitur = 500000;
            else if (skor >= 50) tarifPerFitur = 400000;
            else tarifPerFitur = 250000;

            return tarifPerFitur * Fitur;
        }
    }
}