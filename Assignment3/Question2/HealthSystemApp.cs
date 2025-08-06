using Assignment3.Question2.Models;
using Assignment3.Question2.Repositories;

namespace Assignment3.Question2
{
    public class HealthSystemApp
    {
        private Repository<Patient> _patientRepo;
        private Repository<Prescription> _prescriptionRepo;
        private Dictionary<int, List<Prescription>> _prescriptionMap;

        public HealthSystemApp()
        {
            _patientRepo = new Repository<Patient>();
            _prescriptionRepo = new Repository<Prescription>();
            _prescriptionMap = new Dictionary<int, List<Prescription>>();
        }

        public void SeedData()
        {
            Console.WriteLine("--- Seeding Data ---");
            _patientRepo.Add(new Patient(1, "Alice Smith", 30, "Female"));
            _patientRepo.Add(new Patient(2, "Bob Johnson", 45, "Male"));
            _patientRepo.Add(new Patient(3, "Charlie Brown", 25, "Male"));
            Console.WriteLine();

            _prescriptionRepo.Add(new Prescription(101, 1, "Amoxicillin", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(102, 2, "Lisinopril", DateTime.Now.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(103, 1, "Ibuprofen", DateTime.Now.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(104, 3, "Zyrtec", DateTime.Now.AddDays(-7)));
            _prescriptionRepo.Add(new Prescription(105, 2, "Metformin", DateTime.Now.AddDays(-1)));
            Console.WriteLine();
        }

        public void BuildPrescriptionMap()
        {
            Console.WriteLine("--- Building Prescription Map ---");
            _prescriptionMap.Clear();

            var allPrescriptions = _prescriptionRepo.GetAll();

            foreach (var prescription in allPrescriptions)
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }
                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
            Console.WriteLine("Prescription map built successfully.");
        }

        public void PrintAllPatients()
        {
            var patients = _patientRepo.GetAll();
            if (patients.Any())
            {
                foreach (var patient in patients)
                {
                    Console.WriteLine(patient);
                }
            }
            else
            {
                Console.WriteLine("No patients found.");
            }
        }

        public void PrintPrescriptionsForPatient(int patientId)
        {
            var prescriptions = GetPrescriptionsByPatientId(patientId);
            if (prescriptions.Any())
            {
                foreach (var prescription in prescriptions)
                {
                    Console.WriteLine(prescription);
                }
            }
            else
            {
                Console.WriteLine($"No prescriptions found for Patient ID {patientId}.");
            }
        }

        private List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            if (_prescriptionMap.TryGetValue(patientId, out List<Prescription>? patientPrescriptions))
            {
                return patientPrescriptions;
            }
            return new List<Prescription>();
        }
    }
}