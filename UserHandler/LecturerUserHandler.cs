using MuheebdeenProject.Domain;

using MuheebdeenProject.Services.LecturerService;

namespace MuheebdeenProject.UserHandler;

public static class LecturerUserHandler
{
     public static void Run()
    {
        while (true)
        {
            Console.WriteLine("-------Admin Login------");
            Console.WriteLine("------------");
            
            Console.WriteLine("Enter AdminId: ");
            var adminId = Console.ReadLine();
            Console.WriteLine("------------");
            
            Console.WriteLine("Enter Admin Password: ");
            var adminPass = Console.ReadLine();

            if (!(LecturerServiceRepository.ValidateAdmin(adminId, adminPass)))
            {
                Console.WriteLine("Invalid Admin input");
                return;
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("Login successful");
            Console.WriteLine("---------------------");
            
            var running = true;
            while (running)
            {
                Console.WriteLine("1. Add Lecturer \n2. Get staff by ID \n3. View all Lecturers \n4. Update Lecturer Information \n5. Delete Lecturer \n6. Exit");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Lecturer name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("----------------------");

                        Console.WriteLine("Lecturer Age: ");
                        var age = Console.ReadLine();
                        Console.WriteLine("-----------------------");
                        
                        Console.WriteLine("Lecturer address: ");
                        var address = Console.ReadLine();
                        Console.WriteLine("-----------------------");
                        
                        Console.WriteLine("Lecturer Gender \n1. Male \n2. Female");
                        var genderchoice = Console.ReadLine();

                        if (!Enum.TryParse(genderchoice, out Gender newGender))
                        {
                            Console.WriteLine("Invalid gender");
                            Console.WriteLine("----------------------");
                            continue;
                        }
                        
                        //Aad student
                    LecturerServiceRepository.AddLecturer(name, age, address, newGender);
                        Console.WriteLine("Lecturer successfully added");
                        break;
                    
                    case "2":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Get Lecturer by ID");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Lecturer ID to get lecturer: ");
                        string searchId = Console.ReadLine();
                        var Lecturer = LecturerServiceRepository.GetLecturetbyId(searchId);
                        
                        if (Lecturer != null)
                        {
                         Console.WriteLine($"Found: {Lecturer.Name} | {Lecturer.Age} | {Lecturer.Address} | {Lecturer.Gender}"); 
                        }
                        else
                        {
                            Console.WriteLine("Lecturer not found");
                        }
                        break;
                    
                    case "3":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Get all Lecturers");
                        Console.WriteLine("-------------------");
                        var lecturers = LecturerServiceRepository.GetAllStaff();
                        foreach (var lecturer in lecturers)

                        {
                            Console.WriteLine(($" Name: {lecturer.Name} | StaffID: {lecturer.StaffId} | Age: {lecturer.Age} | Address: {lecturer.Address} | Gender: {lecturer.Gender}"));
                        }

                        break;
                    
                    case "4":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Update Lecturer information");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Lecturer ID to update: ");
                        string idToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new age: ");
                        string ageToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new address: ");
                        string addressToUpdate = Console.ReadLine();

                        LecturerServiceRepository.UpdateStaffInfo(idToUpdate,  addressToUpdate, ageToUpdate);
                        break;
                    
                    case "5":
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Delete Lecturer");
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Enter Lecturer ID to delete student: ");
                        string idToDelete = Console.ReadLine();
                        bool isDeleted = LecturerServiceRepository.DeleteLecturer(idToDelete);
                        if (isDeleted)
                        {
                            Console.WriteLine("Lecturer successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Lecturer ID not found");
                        }
                        break;
                    
                    case "6":
                        running = false;
                        Console.WriteLine("LOGING OUT......");
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }

}