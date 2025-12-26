#include <iostream>
#include <windows.h>
using namespace std;
void gotoxy(int x, int y)
{
    COORD coord;
    coord.X = x;
    coord.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

// ----------------------------
// GLOBAL PARALLEL ARRAYS
// ----------------------------
const int MAX = 50;

int bookID[MAX];
int bookAvailable[MAX]; // 1 = available, 0 = issued
int bookCount = 0;

int studentID[MAX];
int studentCount = 0;

int issuedBookID[MAX];
int issuedToStudent[MAX];
int issueCount = 0;

const char *libraryBanner[] = {
    u8"                                                            ",
    u8"  ██╗     ██╗██████╗ ██████╗  █████╗ ██████╗   ██╗   ██╗     ",
    u8"  ██║     ██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗  ╚██╗ ██╔╝     ",
    u8"  ██║     ██║██████╔╝██████╔╝███████║██████╔╝   ╚████╔╝      ",
    u8"  ██║     ██║██║ ██║ ██╔═██║ ██╔══██║██╔══██║    ╚██╔╝       ",
    u8"  ███████╗██║██╚███  ██║ ██║ ██║  ██║██║  ██║     ██║        ",
    u8"  ╚══════╝╚═╝ ╚═══╝  ╚═╝ ╚═╝ ╚═╝  ╚═╝╚═╝  ╚═╝     ╚═╝        ",
    u8"                                                             ",
    u8"               Welocome to the system of  LIBRARY            "};
void printBanner(const char *banner[], int lines)
{
    for (int i = 0; i < lines; i++)
    {
        std::cout << banner[i] << std::endl;
    }
}

// ----------------------------
// FIND BOOK INDEX
// ----------------------------
int findBook(int id)
{
    for (int i = 0; i < bookCount; i++)
    {
        if (bookID[i] == id)
            return i;
    }
    return -1;
}

// ----------------------------
// FIND STUDENT INDEX
// ----------------------------
int findStudent(int id)
{
    for (int i = 0; i < studentCount; i++)
    {
        if (studentID[i] == id)
            return i;
    }
    return -1;
}

// ----------------------------
// LIBRARIAN FUNCTIONS
// ----------------------------

// Add a book
void addBook()
{
    if (bookCount >= MAX)
    {
        cout << "No space for more books.\n";
        return;
    }

    cout << "Enter Book ID: ";
    int id;
    cin >> id;

    int idx = findBook(id);
    if (idx != -1)
    {
        cout << "Book already exists.\n";
        return;
    }

    bookID[bookCount] = id;
    bookAvailable[bookCount] = 1; // available
    bookCount++;

    cout << "Book Added.\n";
}

// View all books
void viewBooks()
{
    if (bookCount == 0)
    {
        cout << "No books.\n";
        return;
    }

    cout << "ID\tAvailable\n";
    for (int i = 0; i < bookCount; i++)
    {
        cout << bookID[i] << "\t";
        if (bookAvailable[i] == 1)
            cout << "Yes\n";
        else
            cout << "No\n";
    }
}

// Delete book
void deleteBook()
{
    cout << "Enter Book ID to delete: ";
    int id;
    cin >> id;

    int idx = findBook(id);
    if (idx == -1)
    {
        cout << "Book not found.\n";
        return;
    }

    for (int i = idx; i < bookCount - 1; i++)
    {
        bookID[i] = bookID[i + 1];
        bookAvailable[i] = bookAvailable[i + 1];
    }

    bookCount--;
    cout << "Book Deleted.\n";
}

// Add student
void addStudent()
{
    if (studentCount >= MAX)
    {
        cout << "No space for more students.\n";
        return;
    }

    cout << "Enter Student ID: ";
    int id;
    cin >> id;

    int idx = findStudent(id);
    if (idx != -1)
    {
        cout << "Student already exists.\n";
        return;
    }

    studentID[studentCount] = id;
    studentCount++;

    cout << "Student Added.\n";
}

// View students
void viewStudents()
{
    if (studentCount == 0)
    {
        cout << "+----------------------+-----------------------------+\n";
        cout << "|       STATUS         |   no students               .|\n";
        cout << "+----------------------+------------------------------+\n";
        return;
    }

    cout << "Student IDs:\n";
    for (int i = 0; i < studentCount; i++)
    {
        cout << studentID[i] << "\n";
    }
}

// ----------------------------
// STUDENT FUNCTIONS
// ----------------------------

// View available books
void studentViewBooks()
{
    bool found = false;

        cout << "+----------------------+------------------------------+\n";
        cout << "|       STATUS         |   This book is     available.|\n";
        cout << "+----------------------+------------------------------+\n";
    for (int i = 0; i < bookCount; i++)
    {
        if (bookAvailable[i] == 1)
        {
            cout << bookID[i] << "\n";
            found = true;
        }
    }

    if (!found)
        cout << "+----------------------+-----------------------------+\n";
        cout << "|       STATUS         |   This book is not available.|\n";
        cout << "+----------------------+------------------------------+\n";
}

// Borrow book
void borrowBook(int sid)
{
    cout << "Enter Book ID: ";
    int id;
    cin >> id;

    int idx = findBook(id);

    if (idx == -1)
    {
        cout << "+----------------------+---------------------+\n";
        cout << "|       STATUS         |   Book not found.   |\n";
        cout << "+----------------------+---------------------+\n";
        return;
    }

    if (bookAvailable[idx] == 0)
    {
        cout << "+----------------------+---------------------------+\n";
        cout << "|       STATUS         |   This book is    issued. |\n";
        cout << "+----------------------+---------------------------+\n";
        return;
    }

    bookAvailable[idx] = 0;

    issuedBookID[issueCount] = id;
    issuedToStudent[issueCount] = sid;
    issueCount++;

    cout << "Book Issued.\n";
}

// Return book
void returnBook(int sid)
{
    cout << "Enter Book ID to return: ";
    int id;
    cin >> id;

    int idx = findBook(id);

    if (idx == -1)
    {
    cout << "+----------------------+---------------------+\n";
    cout << "|       STATUS         |   Book not found.   |\n";
    cout << "+----------------------+---------------------+\n";
        return;
    }

    if (bookAvailable[idx] == 1)
    {
        cout << "+----------------------+---------------------------+\n";
        cout << "|       STATUS         |   This book is not issued. |\n";
        cout << "+----------------------+---------------------------+\n";

        return;
    }

    // Mark as available again
    bookAvailable[idx] = 1;

    cout << "Book Returned.\n";
}

// View issued books of student
void viewMyBooks(int sid)
{
    bool found = false;

    cout << "Your Issued Books:\n";
    for (int i = 0; i < issueCount; i++)
    {
        if (issuedToStudent[i] == sid)
        {
            cout << issuedBookID[i] << "\n";
            found = true;
        }
    }

    if (!found)
        cout << "You have no issued books.\n";
}

// ----------------------------
// MENUS
// ----------------------------

void librarianMenu()
{
    while (true)
    {
        cout << "\n====================================\n";
        cout << "        LIBRARY MANAGEMENT SYSTEM    \n";
        cout << "====================================\n";
        system("color 7D");
        Sleep(500);
        cout << "+-------------------+-------------------+\n";
        cout << "|       Option      |      Action       |\n";
        cout << "+-------------------+-------------------+\n";
        cout << "| 1                 | Add Book          |\n";
        cout << "| 2                 | View Books        |\n";
        cout << "| 3                 | Delete Book       |\n";
        cout << "| 4                 | Add Student       |\n";
        cout << "| 5                 | View Students     |\n";
        cout << "| 0                 | Logout            |\n";
        cout << "+-------------------+-------------------+\n";
        cout << "Enter choice: ";

        int ch;
        cin >> ch;

        if (ch == 0)
            break;
        else if (ch == 1)
            addBook();
        else if (ch == 2)
            viewBooks();
        else if (ch == 3)
            deleteBook();
        else if (ch == 4)
            addStudent();
        else if (ch == 5)
            viewStudents();
        else
            cout << "Invalid.\n";
    }
}

void studentMenu(int sid)
{
    while (true)
    {
        system("color 6D");
        cout << "\n+----------------------+---------------------------+\n";
        cout << "|       STUDENT MENU   |         Options           |\n";
        cout << "+----------------------+---------------------------+\n";
        cout << "| 1                    | View Available Books      |\n";
        cout << "| 2                    | Borrow Book               |\n";
        cout << "| 3                    | Return Book               |\n";
        cout << "| 4                    | View My Books             |\n";
        cout << "| 0                    | Logout                    |\n";
        cout << "+----------------------+---------------------------+\n";
        cout << "Enter choice: ";

        int ch;
        cin >> ch;

        if (ch == 0)
            break;
        else if (ch == 1)
            studentViewBooks();
        else if (ch == 2)
            borrowBook(sid);
        else if (ch == 3)
            returnBook(sid);
        else if (ch == 4)
            viewMyBooks(sid);
        else
            cout << "Invalid.\n";
    }
}

// ----------------------------
// MAIN FUNCTION
// ----------------------------
int main()

{
    system("cls");
    system("color 60");
    int lines = 9;
    system("cls");
    gotoxy(30, 10);
    printBanner(libraryBanner, lines);
    Sleep(1500);

    while (true)
    {
        system("color 3A");
        Sleep(550);
        cout << "\n+-------------------+-------------------+\n";
        cout << "|       Option      |      Action       |\n";
        cout << "+-------------------+-------------------+\n";
        cout << "| 1                 | Librarian         |\n";
        cout << "| 2                 | Student           |\n";
        cout << "| 0                 | Exit              |\n";
        cout << "+-------------------+-------------------+\n";
        cout << "Enter choice: ";

        int user;
        cin >> user;

        if (user == 0)
        {
            cout << "Goodbye!";
            break;
        }
        else if (user == 1)
        {
            system("cls");
            librarianMenu();
        }
        else if (user == 2)
        {
            system("cls");
            cout << "Enter Student ID: ";
            int sid;
            cin >> sid;

            int idx = findStudent(sid);

            if (idx == -1)
                cout << "Student not found.\n";
            else
                studentMenu(sid);
        }
        else
        {
            cout << "Invalid.\n";
        }
    }

    return 0;
}
