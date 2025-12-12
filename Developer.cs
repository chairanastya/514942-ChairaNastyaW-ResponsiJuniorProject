using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace responsi
{
    // 1. ABSTRACTION
    public abstract class Developer
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int IdProyek { get; set; }
        public string NamaProyek { get; set; } 
        public string Status { get; set; }
        public int Fitur { get; set; }
        public int Bug { get; set; }

        // Abstract Methods (Polymorphism)
        public abstract double HitungSkor();
        public abstract decimal HitungGaji();
    }

    // 2. INHERITANCE & POLYMORPHISM
    public class FullTimeDeveloper : Developer
    {
        public FullTimeDeveloper() { Status = "Full Time"; }
        public override double HitungSkor()
        {
            double skor = (10 * Fitur) - (5 * Bug);
            return skor < 0 ? 0 : skor; 
        }
        public override decimal HitungGaji()
        {
            decimal gajiPokok = 5000000;
            decimal bonus = (decimal)HitungSkor() * 20000;
            return gajiPokok + bonus;
        }
    }

    // 3. INHERITANCE & POLYMORPHISM
    public class FreelanceDeveloper : Developer
    {
        public FreelanceDeveloper() { Status = "Freelance"; }
        public override double HitungSkor()
        {
            if (Fitur == 0) return 0;
            double ratio = (2.0 * Bug) / (3.0 * Fitur);
            double skor = 100 * (1 - ratio);
            return skor < 0 ? 0 : skor; 
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