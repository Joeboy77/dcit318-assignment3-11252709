using Assignment3.Question1;
using Assignment3.Question2;
using Assignment3.Question3;
using Assignment3.Question3.Exceptions; // Specific exception for Q3
using Assignment3.Question3.Models;    // Specific models for Q3
using Assignment3.Question4;
using Assignment3.Question4.Exceptions; // Specific exceptions for Q4
using Assignment3.Question4.Models;    // Specific models for Q4
using Assignment3.Question5;


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consolidated AAS3 Systems Demonstration");

            // --- Question 1: Finance Management System ---
            Console.WriteLine("Demonstrating Finance Management System");
            FinanceApp financeApp = new FinanceApp();
            financeApp.Run();
            Console.WriteLine("\nFinance Management System Demo Complete.\n");

            // --- Question 2: Healthcare System ---
            Console.WriteLine("Demonstrating Healthcare System");
            HealthSystemApp healthApp = new HealthSystemApp();
            healthApp.SeedData();
            healthApp.BuildPrescriptionMap();
            Console.WriteLine();

            Console.WriteLine("All Patients");
            healthApp.PrintAllPatients();
            Console.WriteLine();

            int patientIdToSearch = 1;
            Console.WriteLine($"--- Prescriptions for Patient ID {patientIdToSearch} ---");
            healthApp.PrintPrescriptionsForPatient(patientIdToSearch);
            Console.WriteLine("\nHealthcare System Demo Complete.\n");

            // --- Question 3: Warehouse Inventory Management System ---
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("--- Demonstrating Warehouse Inventory System ---");
            Console.WriteLine("-------------------------------------------------");
            WarehouseManager warehouseManager = new WarehouseManager();
            warehouseManager.SeedData();
            Console.WriteLine();

            Console.WriteLine("--- All Grocery Items ---");
            warehouseManager.PrintAllItems(warehouseManager.GetGroceryRepository());
            Console.WriteLine();

            Console.WriteLine("--- All Electronic Items ---");
            warehouseManager.PrintAllItems(warehouseManager.GetElectronicRepository());
            Console.WriteLine();

            Console.WriteLine("--- Demonstrating Exception Handling (Warehouse) ---");

            Console.WriteLine("\nAttempting to add a duplicate Electronic Item (ID 101):");
            try
            {
                warehouseManager.GetElectronicRepository().AddItem(new ElectronicItem(101, "Laptop", 5, "Dell", 12));
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            Console.WriteLine();

            Console.WriteLine("Attempting to remove a non-existent Grocery Item (ID 999):");
            warehouseManager.RemoveItemById(warehouseManager.GetGroceryRepository(), 999);
            Console.WriteLine();

            Console.WriteLine("Attempting to update Grocery Item (ID 1) with invalid quantity (-5):");
            warehouseManager.IncreaseStock(warehouseManager.GetGroceryRepository(), 1, -5);
            Console.WriteLine("\nWarehouse Inventory System Demo Complete.\n");

            // --- Question 4: School Grading System ---
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("--- Demonstrating School Grading System ---");
            Console.WriteLine("-------------------------------------------------");
            string inputFilePath = "Input.txt";
            string outputFilePath = "Report.txt";

            StudentResultProcessor studentProcessor = new StudentResultProcessor();

            try
            {
                Console.WriteLine($"Attempting to read students from '{inputFilePath}'...");
                List<Student> students = studentProcessor.ReadStudentsFromFile(inputFilePath);
                Console.WriteLine($"Successfully read {students.Count} valid student records.");
                Console.WriteLine();

                Console.WriteLine($"Attempting to write report to '{outputFilePath}'...");
                studentProcessor.WriteReportToFile(students, outputFilePath);
                Console.WriteLine($"Report successfully written to '{outputFilePath}'.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"ERROR: Input file not found: {ex.Message}");
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine($"ERROR: Invalid score format: {ex.Message}");
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine($"ERROR: Missing field in student record: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            Console.WriteLine("\nSchool Grading System Demo Complete.\n");

            // --- Question 5: Inventory Records with File Operations ---
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("--- Demonstrating Inventory Records System ---");
            Console.WriteLine("-------------------------------------------------");
            InventoryApp inventoryApp = new InventoryApp();
            Console.WriteLine();

            Console.WriteLine("--- Seeding Sample Data ---");
            inventoryApp.SeedSampleData();
            Console.WriteLine();

            Console.WriteLine("--- Saving Data to File ---");
            inventoryApp.SaveData();
            Console.WriteLine();

            Console.WriteLine("--- Simulating New Session (Clearing Memory) ---");
            inventoryApp = new InventoryApp();
            Console.WriteLine("Application memory cleared.");
            Console.WriteLine();

            Console.WriteLine("--- Loading Data from File ---");
            inventoryApp.LoadData();
            Console.WriteLine();

            Console.WriteLine("--- Printing All Loaded Items ---");
            inventoryApp.PrintAllItems();
            Console.WriteLine("\nInventory Records System Demo Complete.\n");


            Console.WriteLine("=================================================");
            Console.WriteLine("--- All AAS3 System Demonstrations Finished ---");
            Console.WriteLine("=================================================");
            Console.ReadKey();
        }
    }
}
