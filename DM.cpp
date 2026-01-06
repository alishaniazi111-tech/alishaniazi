#include <iostream>
#include <windows.h>
#include <fstream>
#include <vector>
using namespace std;
void gotoxy(int x, int y)
{
    COORD c;
    c.X = x;
    c.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), c);
}

// global variables:
const int MAX = 1000;
int beds[MAX];
string patientNames[MAX];
string diseases[MAX];
int patientage[MAX];
char genders[MAX];
int patientTime[MAX]; // NEW: doctor time period for each patient.so no one is left
int patientCount = 0;

// Save only filled patient records
void saveData()
{
    ofstream file("hospital.txt");
    for (int i = 0; i < MAX; i++)
    {
        if (!patientNames[i].empty())
        {
            file << i << " " << patientNames[i] << " "
                 << patientage[i] << " " << genders[i] << " "
                 << diseases[i] << " " << patientTime[i] << endl;
        }
    }
}

// Load patient records
void loadData()
{
    ifstream file("hospital.txt");
    int index, age, time;
    char gender;
    string name, disease;
    while (file >> index >> name >> age >> gender >> disease >> time)
    {
        beds[index] = index;
        patientNames[index] = name;
        patientage[index] = age;
        genders[index] = gender;
        diseases[index] = disease;
        patientTime[index] = time;
        patientCount++;
    }
}

// Attractive banner

const char *hospitalBanner[] = {
    u8"                                                            ",
    u8"  ██╗  ██╗ ██████╗ ██████╗ ██████╗ ██╗████████╗ █████╗ ██╗     ",
    u8"  ██║  ██║██╔═══██╗██╔═    ██╔══██╗██║╚══██╔══╝██╔══██╗██║     ",
    u8"  ███████║██║   ██║██████╔╝██████╔╝██║   ██║   ███████║██║     ",
    u8"  ██╔══██║██║   ██║     ██╗██╔═══╝ ██║   ██║   ██╔══██║██║     ",
    u8"  ██║  ██║╚██████╔╝╚██████╔██║     ██║   ██║   ██║  ██║███████╗",
    u8"  ╚═╝  ╚═╝ ╚═════╝  ╚═════╝╚═╝     ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝",
    u8"                                                            ",
    u8"               Welcome to the system of  HOSPITAL            "};
void headerBanner()
{
    for (const char *line : hospitalBanner)
    {
        cout << line << endl;
    }
}
void banner()
{
cout<< " REMEMER: HEALTH IS WEALTH "<< endl;
cout<< " 1. STAY SAFE, STAY HEALTHY "<< endl;
cout<< " 2. WASH YOUR HANDS REGULARLY "<< endl;
cout<< " 3. WEAR A MASK IN CROWDED PLACES "<< endl;
cout<< " 4. MAINTAIN SOCIAL DISTANCING "<< endl;
cout<< " 5. GET VACCINATED "<< endl;
cout<< " 6. TAKE CARE OF YOUR MENTAL HEALTH "<< endl;
cout<< " 7. EAT A BALANCED DIET "<< endl;
cout<< " 8. EXERCISE REGULARLY "<< endl;

}
bool isSevere(string disease)
{
    string severeDiseases[] = {"cancer", "heartAttack", "stroke", "covid", "pneumonia", "ebola", "mers", "sars", "dengue", "malaria", "tuberculosis", "hepatitis", "hiv", "aids", "zika", "yellowFever", "cholera", "plague", "meningitis", "rabies", "anthrax", "botulism", "tetanus", "leprosy", "typhoid", "lassaFever", "marburgVirus", "nipahVirus", "hendraVirus", "lassaFever", "crimeanCongoHemorrhagicFever"};
    for (string d : severeDiseases)
    {
        if (disease == d)
            return true;
    }
    return false;
}

// Add patient details
void addPatient()
{
    int index;
    string name, disease;
    int age;
    char gender;

    cout << "Enter bed index (0-" << MAX - 1 << "): ";
    cin >> index;

    if (index < 0 || index >= MAX)
    {
        cout << "Invalid bed index!\n";
        return;
    }

    cout << "Name: ";
    cin >> name;
    cout << "Age: ";
    cin >> age;
    cout << "Gender (M/F): ";
    cin >> gender;
    cout << "Disease: ";
    cin >> disease;

    beds[index] = index;
    patientNames[index] = name;
    patientage[index] = age;
    genders[index] = gender;
    diseases[index] = disease;

    // Assign doctor time based on severity
    if (isSevere(disease))
        patientTime[index] = 60; // severe cases = 60 mins
    else
        patientTime[index] = 30; // normal cases = 30 mins

    patientCount++;
    cout << "\nPatient added successfully!. May Allah bless you with good health and fast recovery!\n";
}

// View all patient records
void viewPatientDetails()
{
    cout << "\n--- Patient Records ---\n";
    if (patientCount == 0)
    {
        cout << "No patient records found.\n";
        return;
    }

    for (int i = 0; i < MAX; i++)
    {
        if (!patientNames[i].empty())
        {
            cout << "Bed: " << i
                 << " | Name: " << patientNames[i]
                 << " | Age: " << patientage[i]
                 << " | Gender: " << genders[i]
                 << " | Disease: " << diseases[i]
                 << " | Doctor Time: " << patientTime[i] << " mins" << endl;
        }
    }
}

// Prioritize patients with severe diseases
void prioritizePatients()
{
    cout << "\n--- Prioritized Patient List ---\n";
    if (patientCount == 0)
    {
        cout << "No patient records found.\n";
        return;
    }

    vector<int> severeList, normalList;

    for (int i = 0; i < MAX; i++)
    {
        if (!patientNames[i].empty())
        {
            if (isSevere(diseases[i]))
                severeList.push_back(i);
            else
                normalList.push_back(i);
        }
    }

    cout << "\n*** Severe Cases (More Doctor Time) ***\n";
    for (int idx : severeList)
    {
        cout << "Bed: " << idx
             << " | Name: " << patientNames[idx]
             << " | Age: " << patientage[idx]
             << " | Gender: " << genders[idx]
             << " | Disease: " << diseases[idx]
             << " | Doctor Time: " << patientTime[idx] << " mins\n";
    }

    cout << "\n*** Normal Cases ***\n";
    for (int idx : normalList)
    {
        cout << "Bed: " << idx
             << " | Name: " << patientNames[idx]
             << " | Age: " << patientage[idx]
             << " | Gender: " << genders[idx]
             << " | Disease: " << diseases[idx]
             << " | Doctor Time: " << patientTime[idx] << " mins\n";
    }
}
// Function to view patient time periods
void viewPatientTimePeriod()
{
    cout << "\n--- Patient Time Periods ---\n";
    if (patientCount == 0)
    {
        cout << "No patient records found.\n";
        return;
    }

    for (int i = 0; i < MAX; i++)
    {
        if (!patientNames[i].empty())
        {
            cout << "Bed: " << i
                 << " | Name: " << patientNames[i]
                 << " | Disease: " << diseases[i]
                 << " | Doctor Time Period: " << patientTime[i] << " mins\n";
        }
    }
}
void searchPatient()
{
    string searchName;
    cout << "Enter patient name to search: ";
    cin >> searchName;

    bool found = false;
    for (int i = 0; i < MAX; i++)
    {
        if (patientNames[i] == searchName)
        {
            cout << "Bed: " << i
                 << " | Name: " << patientNames[i]
                 << " | Age: " << patientage[i]
                 << " | Gender: " << genders[i]
                 << " | Disease: " << diseases[i]
                 << " | Doctor Time: " << patientTime[i] << " mins\n";
            found = true;
        }
    }
    if (!found)
        cout << "Patient not found.\n";
}
void dischargePatient()
{
    int index;
    cout << "Enter bed index to discharge: ";
    cin >> index;

    if (index < 0 || index >= MAX || patientNames[index].empty())
    {
        cout << "Invalid bed index or no patient found!\n";
        return;
    }

    patientNames[index] = "";
    diseases[index] = "";
    patientage[index] = 0;
    genders[index] = ' ';
    patientTime[index] = 0;
    patientCount--;

    cout << "Patient discharged successfully!.Be grateful for Allah almighty\n";
}
void updatePatient()
{
    int index;
    cout << "Enter bed index to update: ";
    cin >> index;

    if (index < 0 || index >= MAX || patientNames[index].empty())
    {
        cout << "Invalid bed index or no patient found!\n";
        return;
    }

    cout << "Updating details for " << patientNames[index] << "...\n";
    cout << "New Name: ";
    cin >> patientNames[index];
    cout << "New Age: ";
    cin >> patientage[index];
    cout << "New Gender (M/F): ";
    cin >> genders[index];
    cout << "New Disease: ";
    cin >> diseases[index];

    // Recalculate doctor time
    if (isSevere(diseases[index]))
        patientTime[index] = 60;
    else
        patientTime[index] = 30;

    cout << "Patient details updated successfully!\n";
}
void hospitalStats()
{
    int severeCount = 0, normalCount = 0;
    for (int i = 0; i < MAX; i++)
    {
        if (!patientNames[i].empty())
        {
            if (isSevere(diseases[i]))
                severeCount++;
            else
                normalCount++;
        }
    }
    cout << "\n--- Hospital Statistics ---\n";
    cout << "Total Patients: " << patientCount << endl;
    cout << "Severe Cases: " << severeCount << endl;
    cout << "Normal Cases: " << normalCount << endl;
}

// Menu
void hospitalMenu()
{
    while (true)
    {
    cout << "+-------------------------------------------+\n";
    cout << "|         HOSPITAL MANAGEMENT SYSTEM        |\n";
    cout << "+-------------------------------------------+\n";
    cout << "|  No. |              Option                |\n";
    cout << "+------+------------------------------------+\n";
    cout << "|  1   | Add Patient Details                |\n";
    cout << "|  2   | View Patient Details               |\n";
    cout << "|  3   | Prioritize Severe Patients         |\n";
    cout << "|  4   | View Patient Time Periods          |\n";
    cout << "|  5   | Search Patient                     |\n";
    cout << "|  6   | Discharge Patient                  |\n";
    cout << "|  7   | Update Patient Details             |\n";
    cout << "|  8   | Hospital Statistics                |\n";
    cout << "|  9   | Exit                               |\n";
    cout << "+-------------------------------------------+\n";
    cout << "Enter your choice: ";


        int choice;
        cin >> choice;

        if (choice == 1)
        {
            addPatient();
        }
        else if (choice == 2)
        {
            viewPatientDetails();
        }
        else if (choice == 3)
        {
            prioritizePatients();
        }
        else if (choice == 4)
        {
            viewPatientTimePeriod();
        }
        else if (choice == 5)
        {
            searchPatient();
        }
        else if (choice == 6)
        {
            dischargePatient();
        }
        else if (choice == 7)
        {
            updatePatient();
        }
        else if (choice == 8)
        {
            hospitalStats();
        }
        else if (choice == 9)
        {
            cout << "Exiting... Goodbye!\n";
            return; // exit the menu loop
        }
        else
        {
            cout << "Invalid choice! Please try again.\n";
        }
    }
}
// Main
int main()
{
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
    system("cls");
    system("color 45");
    gotoxy(30, 10);
    headerBanner();
    Sleep(1500);
    system("cls");
    system("color 60");
    gotoxy(30, 10);
    banner();
    Sleep(1500);
    loadData();
    hospitalMenu();
    saveData();
    return 0;
}