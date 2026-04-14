namespace HMS_Project
{

        internal class Program
        {
            // Data storage using parallel arrays ( global scope )
            static string[] patientNames = new string[100];
            static string[] patientIDs = new string[100];
            static string[] diagnoses = new string[100];
            static bool[] admitted = new bool[100];
            static string[] assignedDoctors = new string[100];
            static string[] departments = new string[100];
            static int[] visitCount = new int[100];
            static double[] billingAmounts = new double[100];
            static bool[] hasAppointment = new bool[100]; // true = appointment booked
            static DateTime[] lastVisitDate = new DateTime[100]; // e.g. "2025-08-20"
            static DateTime[] lastDischargeDate = new DateTime[100]; // e.g. "2025-08-25"
            static int[] daysInHospital = new int[100]; // number of days between admission and discharge
            static string[] bloodType = new string[100]; // e.g. "A+", "O-", etc.
            static string[] doctorNames = new string[50];
            static int[] doctorAvailableSlots = new int[50];
            static int[] doctorVisitCount = new int[50];
            const double BASE_SALARY = 300;
            const double BONUS_PER_VISIT = 15;

            static int lastDoctorIndex = -1;

            static int patientIndex = -1;

            ////////////////////////////////////////////////////////////////////////////////////////////////


            static public void seedData() //no parameter and no return value
            {

                //seed data for testing
                patientIndex++;
                patientNames[patientIndex] = "Ali Hassan ";
                patientIDs[patientIndex] = "P001";
                diagnoses[patientIndex] = "Flu";
                departments[patientIndex] = "General";
                admitted[patientIndex] = false;
                assignedDoctors[patientIndex] = " ";
                visitCount[patientIndex] = 2;
                billingAmounts[patientIndex] = 0;
                hasAppointment[patientIndex] = false;
                lastVisitDate[patientIndex] = new DateTime(2025, 01, 10);
                lastDischargeDate[patientIndex] = new DateTime(2025, 01, 15);
                daysInHospital[patientIndex] = 12;
                bloodType[patientIndex] = "A+";



                //seed data patient 2
                patientIndex++;
                patientNames[patientIndex] = "Sara Ahmed";
                patientIDs[patientIndex] = "P002";
                diagnoses[patientIndex] = "Fracture";
                departments[patientIndex] = "Orthopedics";
                admitted[patientIndex] = true;
                assignedDoctors[patientIndex] = "Dr. Noor";
                visitCount[patientIndex] = 4;
                billingAmounts[patientIndex] = 0;
                hasAppointment[patientIndex] = false;
                lastVisitDate[patientIndex] = new DateTime(2025, 03, 02);
                lastDischargeDate[patientIndex] = DateTime.MinValue;
                daysInHospital[patientIndex] = 8;
                bloodType[patientIndex] = "O-";


                //seed data patient 3
                patientIndex++;
                patientNames[patientIndex] = "Omar Khalid";
                patientIDs[patientIndex] = "P003";
                diagnoses[patientIndex] = "Diabetes";
                departments[patientIndex] = "Cardiology";
                admitted[patientIndex] = false;
                assignedDoctors[patientIndex] = " ";
                visitCount[patientIndex] = 1;
                billingAmounts[patientIndex] = 0;
                hasAppointment[patientIndex] = false;
                lastVisitDate[patientIndex] = new DateTime(2024, 12, 20);
                lastDischargeDate[patientIndex] = new DateTime(2024, 12, 28);
                daysInHospital[patientIndex] = 5;
                bloodType[patientIndex] = "B+";

                lastDoctorIndex = 0;

                doctorNames[lastDoctorIndex] = "Dr. Noor";
                doctorAvailableSlots[lastDoctorIndex] = 5;
                doctorVisitCount[lastDoctorIndex] = 0;

                lastDoctorIndex++;

                doctorNames[lastDoctorIndex] = "Dr. Salem";
                doctorAvailableSlots[lastDoctorIndex] = 3;
                doctorVisitCount[lastDoctorIndex] = 0;

                lastDoctorIndex++;

                doctorNames[lastDoctorIndex] = "Dr. Hana";
                doctorAvailableSlots[lastDoctorIndex] = 8;
                doctorVisitCount[lastDoctorIndex] = 0;



            }
            static public void DisplayMenu() //no parameter and no return value
            {

                Console.WriteLine("===== Healthcare Management System =====");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Register New Patient");
                Console.WriteLine("2. Admit Patient");
                Console.WriteLine("3. Discharge Patient");
                Console.WriteLine("4. Search Patient");
                Console.WriteLine("5. List All Admitted Patients");
                Console.WriteLine("6. Transfer Patient to Another Doctor");
                Console.WriteLine("7. View Most Visited Patients");
                Console.WriteLine("8. Search Patients by Department");
                Console.WriteLine("9. Billing Report");
                Console.WriteLine("10. Exit");
                Console.WriteLine("11. Add Doctor");
                Console.WriteLine("12. Doctor Salary Report");


            }

            static public string RegisterPatient(string nameInput, string bloodInput, string deptInput,
                                               string diagnosisInput) // parameters for patient details, no return value
            {
                if (patientIndex >= 99)
                {
                    Console.WriteLine("Patient limit reached. Cannot register more patients.");
                    return "";
                }

                patientIndex++;

                patientNames[patientIndex] = nameInput;
                diagnoses[patientIndex] = diagnosisInput;
                departments[patientIndex] = deptInput;
                bloodType[patientIndex] = bloodInput;

                int num = patientIndex + 1;
                if (num < 10)
                {
                    patientIDs[patientIndex] = "P00" + num;
                }
                else if (num < 100)
                {
                    patientIDs[patientIndex] = "P0" + num;
                }
                else
                {
                    patientIDs[patientIndex] = "P" + num;
                }


                admitted[patientIndex] = false;
                assignedDoctors[patientIndex] = "";
                visitCount[patientIndex] = 0;
                billingAmounts[patientIndex] = 0;
                lastVisitDate[patientIndex] = DateTime.MinValue;
                lastDischargeDate[patientIndex] = DateTime.MinValue;
                daysInHospital[patientIndex] = 0;

                Console.WriteLine("Patient registered successfully!");

                return patientIDs[patientIndex];

            }
            static public int SearchPatient(string searchInput) // parameter for patient ID or name, returns true if found
            {

                int found = -1;

                for (int i = 0; i <= patientIndex; i++)
                {
                    if (patientNames[i].ToLower() == searchInput.ToLower() || patientIDs[i].ToLower() == searchInput.ToLower())

                    {
                        found = i;
                        break;
                    }
                }


                return found;
            }

            static public void PrintPatientDetails(int index) // parameter for patient index, no return value
            {
                Console.WriteLine("Patient Name:" + patientNames[index]);
                Console.WriteLine("Patient ID:" + patientIDs[index]);
                Console.WriteLine("Diagnosis: " + diagnoses[index]);
                Console.WriteLine("Department:" + departments[index]);
                Console.WriteLine("Admitted:" + admitted[index]);
                if (admitted[index])
                {
                    Console.WriteLine("Assigned Doctor: " + assignedDoctors[index]);
                }
                else
                {
                    Console.WriteLine("Assigned Doctor: Not currently admitted");
                }
                Console.WriteLine("Visit Count:" + visitCount[index]);
                Console.WriteLine("Total Billing Amount: " + billingAmounts[index] + " OMR");
            }

            static public void AdmitPatient()
            {
                Console.Write("Enter Patient ID or Name: ");
                string admitInput = Console.ReadLine();

                bool admitFound = false;

                for (int i = 0; i <= patientIndex; i++)
                {
                    if (patientNames[i] == admitInput || patientIDs[i] == admitInput)
                    {
                        admitFound = true;

                        if (admitted[i] == false)
                        {
                            Console.Write("Enter Doctor Name: ");
                            string doctorName = Console.ReadLine();

                            admitted[i] = true;
                            assignedDoctors[i] = doctorName;
                            visitCount[i]++;

                            DateTime admissionDate = DateTime.Now;
                            lastVisitDate[i] = admissionDate;

                            string formattedDate = admissionDate.ToString("yyyy-MM-dd HH:mm");

                            Console.WriteLine("Patient admitted successfully!");
                            Console.WriteLine("Admitted on: " + formattedDate);
                            Console.WriteLine("Assigned to " + doctorName);

                            if (visitCount[i] > 1)
                            {
                                Console.WriteLine("This patient has been admitted " + visitCount[i] + " times");
                            }
                            else
                            {
                                Console.WriteLine("This is the patient's first admission");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Patient is already admitted under " + assignedDoctors[i]);
                        }
                        break;
                    }
                }

                if (admitFound == false)
                {
                    Console.WriteLine("Patient not found");
                }
            }

            static public void DischargePatient()
            {
                Console.Write("Enter Patient ID or Name: ");
                string dischargeInput = Console.ReadLine();

                bool dischargeFound = false;

                for (int i = 0; i <= patientIndex; i++)
                {
                    if (patientNames[i] == dischargeInput || patientIDs[i] == dischargeInput)
                    {
                        dischargeFound = true;

                        if (admitted[i] == true)
                        {
                            double visitCharges = 0;

                            Console.Write("Was there a consultation fee? (yes/no): ");
                            string consultation = Console.ReadLine().ToLower();

                            if (consultation == "yes")
                            {
                                Console.Write("Enter consultation fee amount: ");
                                double consultAmount;

                                if (double.TryParse(Console.ReadLine(), out consultAmount) && consultAmount > 0)
                                {
                                    visitCharges += consultAmount;
                                    billingAmounts[i] += consultAmount;
                                }
                            }

                            Console.Write("Was there a medication fee? (yes/no): ");
                            string medication = Console.ReadLine().ToLower();

                            if (medication == "yes")
                            {
                                Console.Write("Enter medication fee amount: ");
                                double medAmount;

                                if (double.TryParse(Console.ReadLine(), out medAmount) && medAmount > 0)
                                {
                                    visitCharges += medAmount;
                                    billingAmounts[i] += medAmount;
                                }
                            }

                            DateTime dischargeDate = DateTime.Now;
                            lastDischargeDate[i] = dischargeDate;

                            Console.Write("Enter number of days in hospital: ");
                            int days;

                            if (int.TryParse(Console.ReadLine(), out days) && days > 0)
                            {
                                daysInHospital[i] += days;
                            }

                            admitted[i] = false;
                            assignedDoctors[i] = "";

                            Console.WriteLine("Patient discharged successfully!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("This patient is not currently admitted");
                            break;
                        }
                    }
                }

                if (dischargeFound == false)
                {
                    Console.WriteLine("Patient not found");
                }
            }

            static public void ListAdmittedPatients()
            {
                Console.WriteLine("Admitted Patients:");
                Console.WriteLine("------------------------------");

                Console.Write("Filter by name keyword (press Enter to skip): ");
                string keyword = Console.ReadLine().Trim().ToLower();

                bool hasAdmitted = false;
                int admittedCount = 0;

                double highestBilling = 0;

                for (int i = 0; i <= patientIndex; i++)
                {
                    if (admitted[i] == true)
                    {
                    bool matchKeyword = keyword == "" || patientNames[i].ToLower().Contains(keyword);
    
                    if (matchKeyword)
                        {
                            string admittedSince;

                            if (lastVisitDate[i] == DateTime.MinValue)
                            {
                                admittedSince = "No admission recorded";
                            }
                            else
                            {
                                admittedSince = lastVisitDate[i].ToString("yyyy-MM-dd");
                            }

                            Console.WriteLine("Name: " + patientNames[i] +
                                              " | ID: " + patientIDs[i] +
                                              " | Diagnosis: " + diagnoses[i] +
                                              " | Department: " + departments[i] +
                                              " | Doctor: " + assignedDoctors[i] +
                                              " | Admitted Since: " + admittedSince);

                            hasAdmitted = true;
                            admittedCount++;

                            highestBilling = Math.Max(highestBilling, billingAmounts[i]);
                        }
                    }
                }

                if (hasAdmitted == false)
                {
                    Console.WriteLine("No patients currently admitted");
                }
                else
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Total Admitted Patients: " + admittedCount);
                    Console.WriteLine("Highest billing among admitted patients: " + Math.Round(highestBilling, 2) + " OMR");
                }
            }

            static public void TransferDoctor()
            {
                Console.Write("Enter current doctor name: ");
                string currentDoctor = Console.ReadLine().Trim();

                Console.Write("Enter New Doctor Name: ");
                string newDoctor = Console.ReadLine().Trim();

                currentDoctor = currentDoctor.Replace("Dr ", "Dr. ");
                newDoctor = newDoctor.Replace("Dr ", "Dr. ");

                if (currentDoctor.ToLower() == newDoctor.ToLower())
                {
                    Console.WriteLine("Current doctor and new doctor names are the same.");
                    return;
                }

                bool transferFound = false;

                for (int i = 0; i <= patientIndex; i++)
                {
                    if (assignedDoctors[i] == currentDoctor && admitted[i] == true)
                    {
                        transferFound = true;

                        assignedDoctors[i] = newDoctor;

                        Console.WriteLine("Patient '" + patientNames[i] + "' has been transferred to " + newDoctor);

                        if (lastVisitDate[i] == DateTime.MinValue)
                        {
                            Console.WriteLine("Patient last admitted on: No admission recorded");
                        }
                        else
                        {
                            Console.WriteLine("Patient last admitted on: " + lastVisitDate[i].ToString("yyyy-MM-dd"));
                        }
                        break;
                    }
                }

                if (transferFound == false)
                {
                    Console.WriteLine("No admitted patient found under this doctor");
                }
            }

            static public void ViewMostVisited()
            {
                Console.WriteLine("Most Visited Patients:");
                Console.WriteLine("----------------------------------");
            int maxVisits = visitCount[0];

                for (int i = 0; i <= patientIndex; i++)
                {
                    if (visitCount[i] > maxVisits)
                    {
                        maxVisits = visitCount[i];
                    }
                }

                for (int count = maxVisits; count >= 0; count--)
                {
                    for (int i = 0; i <= patientIndex; i++)
                    {
                        if (visitCount[i] == count)
                        {
                            Console.WriteLine("ID: " + patientIDs[i] +
                                              " | Name: " + patientNames[i] +
                                              " | Department: " + departments[i] +
                                              " | Diagnosis: " + diagnoses[i] +
                                              " | Visits: " + visitCount[i]);
                        }
                    }
                }
            }

            static public void SearchByDepartment()
            {
                Console.Write("Enter department name: ");
                string searchDep = Console.ReadLine();

                bool depFound = false;

                Console.WriteLine("Patients in department '" + searchDep.ToUpper() + "':");
                Console.WriteLine("----------------------------------------");

                for (int i = 0; i <= patientIndex; i++)
                {
                    if (departments[i].ToLower().Contains(searchDep.ToLower()))
                    {
                        depFound = true;

                        string status = admitted[i] ? "Admitted" : "Not Admitted";

                        string displayDiagnosis = diagnoses[i].Length > 15
                            ? diagnoses[i].Substring(0, 15) + "..."
                            : diagnoses[i];

                        Console.WriteLine("ID: " + patientIDs[i] +
                                          " | Name: " + patientNames[i] +
                                          " | Diagnosis: " + displayDiagnosis +
                                          " | Blood Type: " + bloodType[i] +
                                          " | Status: " + status);
                    }
                }

                if (depFound == false)
                {
                    Console.WriteLine("No patients found in this department");
                }
            }

            //// Generates billing report for all patients or individual patient
            static public void BillingReport()
            {
                Console.WriteLine("Billing Report:");
                Console.WriteLine("1. System-wide total");
                Console.WriteLine("2. Individual patient");

                int billingOption;
                if (!int.TryParse(Console.ReadLine(), out billingOption))
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }

                if (billingOption == 1)
                {
                    double totalBilling = 0;
                    double maxBilling = 0;
                    double minBilling = billingAmounts[0];
                    bool hasBilling = false;

                    for (int i = 0; i <= patientIndex; i++)
                    {
                        totalBilling += billingAmounts[i];

                        if (billingAmounts[i] > 0)
                        {
                            if (!hasBilling)
                            {
                                minBilling = billingAmounts[i];
                                hasBilling = true;
                            }

                            maxBilling = Math.Max(maxBilling, billingAmounts[i]);
                            minBilling = Math.Min(minBilling, billingAmounts[i]);
                        }
                    }

                    Console.WriteLine("Total Billing: " + totalBilling);

                    if (hasBilling)
                    {
                        Console.WriteLine("Max Billing: " + maxBilling);
                        Console.WriteLine("Min Billing: " + minBilling);
                    }
                }
                else if (billingOption == 2)
                {
                    Console.Write("Enter patient ID or Name:");
                    string input = Console.ReadLine();

                    int index = SearchPatient(input);

                    if (index == -1)
                    {
                        Console.WriteLine("No billing record found");
                    }
                    else
                    {
                        Random rnd = new Random();
                        int discountPercent = rnd.Next(5, 21); // 5% to 20%

                        double discountAmount = billingAmounts[index] * discountPercent / 100;
                        double finalAmount = billingAmounts[index] - discountAmount;

                        Console.WriteLine("Original Billing: " + billingAmounts[index]);
                        Console.WriteLine("Discount Applied: " + discountPercent + "%");
                        Console.WriteLine("Final Billing: " + Math.Round(finalAmount, 2));
                    }
                }
            }


            //// Handles exit confirmation
            static bool ExitSystem()
            {
                Console.Write("Are you sure you want to exit? (yes/no): ");
                string input = Console.ReadLine().ToLower();

                if (input == "yes")
                {
                    Console.WriteLine("Exiting system...");
                    return true;
                }

                Console.WriteLine("Exit cancelled.");
                return false;
            }

            static public void AddDoctor()
            {
                Console.Write("Enter Doctor Full Name: ");
                string nameInput = Console.ReadLine().Trim();

                if (nameInput == "")
                {
                    Console.WriteLine("Invalid name. Doctor not registered.");
                    return;
                }

                Console.Write("Enter Number of Available Slots: ");
                string slotInput = Console.ReadLine();

                int slots;

                if (!int.TryParse(slotInput, out slots) || slots < 1)
                {
                    Console.WriteLine("Invalid slot count. Doctor not registered.");
                    return;
                }

                // Convert name (trim + keep clean format)
                string formattedName = nameInput;

                bool exists = false;

                for (int i = 0; i <= lastDoctorIndex; i++)
                {
                    if (doctorNames[i].ToLower() == formattedName.ToLower())
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    Console.WriteLine("Doctor already exists in the system.");
                    return;
                }

                // Add doctor
                if (lastDoctorIndex >= 49)
                {
                    Console.WriteLine("Doctor limit reached. Cannot add more doctors.");
                    return;
                }

                lastDoctorIndex++;

                doctorNames[lastDoctorIndex] = formattedName;
                doctorAvailableSlots[lastDoctorIndex] = slots;
                doctorVisitCount[lastDoctorIndex] = 0;

                Console.WriteLine("Doctor " + formattedName +
                                  " registered successfully with " +
                                  slots + " available slots.");
            }

            static public void DoctorSalaryReport()
            {
                if (lastDoctorIndex == -1)
                {
                    Console.WriteLine("No doctors registered in the system.");
                    return;
                }

                Console.WriteLine("Doctor Salary Report:");
                Console.WriteLine("-------------------------------------");

                double highestSalary = 0;
                int highestIndex = -1;

                for (int i = 0; i <= lastDoctorIndex; i++)
                {
                    double salary = BASE_SALARY + (doctorVisitCount[i] * BONUS_PER_VISIT);
                    salary = Math.Round(salary, 2);

                    string salaryText = Convert.ToString(salary);

                    Console.WriteLine(
                        doctorNames[i] +
                        " | Visits: " + doctorVisitCount[i] +
                        " | Available Slots: " + doctorAvailableSlots[i] +
                        " | Salary: " + salaryText + " OMR"
                    );

                    if (salary > highestSalary)
                    {
                        highestSalary = salary;
                        highestIndex = i;
                    }
                }

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Highest earning doctor: " +
                                    doctorNames[highestIndex] +
                                    " — " +
                                    highestSalary +
                                    " OMR");
            }



            static void Main(string[] args)
            {
                //step 1: seed data for testing
                seedData();

                bool exit = false;

                //step 2: main loop to display menu and process user choices
                while (exit == false)
                {

                    DisplayMenu();

                    Console.Write("choose option:");

                    int choice = 0;
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Invlid input. Please enter a number corresponding to the menu options.");


                    }

                    switch (choice)
                    {
                        case 1: // Register New Patient

                            Console.Write("Patient Name:");
                            string nameInput = Console.ReadLine().Trim();
                            Console.Write("Diagnosis:");
                            string diagnosisInput = Console.ReadLine().Trim();
                            Console.Write("Blood Type:");
                            string bloodInput = Console.ReadLine().Trim().ToUpper();
                            Console.Write("Department:");
                            string deptInput = Console.ReadLine().Trim();


                            string PId = RegisterPatient(nameInput, bloodInput, deptInput, diagnosisInput);


                            Console.WriteLine("Generated Patient ID: " + PId);

                            break;


                        case 2: // Admit patient


                            AdmitPatient();
                            break;


                        case 3: // Discharge Patient

                            DischargePatient();
                            break;


                        case 4://Sreach Patient

                            Console.Write("Enter patient ID or Name: ");
                            string searchInput = Console.ReadLine();

                            int searchFound = SearchPatient(searchInput); // call the search function (returns true if found, false if not

                            if (searchFound == -1)
                            {
                                Console.WriteLine("Patient Not Found");
                            }

                            else
                            {

                                PrintPatientDetails(searchFound); // call the print function to display patient details
                            }



                            break;


                        case 5: // List All Admitted Patients 

                            ListAdmittedPatients();
                            break;


                        case 6: // Transfer patient to Another Doctor

                            TransferDoctor();
                            break;



                        case 7: // View Most Visited Patients

                            ViewMostVisited();
                            break;


                        case 8:

                            SearchByDepartment();
                            break;


                        case 9:

                            BillingReport();
                            break;


                        case 10:

                            exit = ExitSystem();
                            break;

                        case 11:

                            AddDoctor();
                            break;

                        case 12:

                            DoctorSalaryReport();
                            break;






                        default:
                            Console.WriteLine("Invalid option. please try again.");
                            break;


                    }

                    Console.WriteLine("Press any key continue...");
                    Console.ReadKey();
                    Console.Clear();
                }


            }
        }
    }


