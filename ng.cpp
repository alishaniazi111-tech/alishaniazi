#include <iostream>
#include <windows.h>
#include <cstdlib> 
#include <ctime>  

using namespace std;


void gotoxy(int x, int y)
{
    COORD c;
    c.X = x;
    c.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), c);
}

char getCharAtxy(short int x, short int y)
{
    CHAR_INFO ci;
    COORD xy = {0, 0};
    SMALL_RECT rect = {x, y, x, y};
    COORD bufSize = {1, 1};

    if (ReadConsoleOutput(GetStdHandle(STD_OUTPUT_HANDLE),
                          &ci,
                          bufSize,
                          xy,
                          &rect))
    {
        return ci.Char.AsciiChar;
    }
    return ' ';
}

// Sizes
const int playerRowSize = 3;
const int playerColSize = 6;
const int groundRowSize = 31;
const int groundColSize = 95;

// Game state
int score = 0;
int pX = 20, pY = 20;       // player position 
int bombX = 69, bombY = 20; // fixed bomb position
int foodX, foodY;           // food position
const char* startBanner[] = {
    u8"                                                                            ",
    u8"                      ██████╗  █████╗ ███╗   ███╗███████╗                   ",
    u8"                     ██╔════╝ ██╔══██╗████╗ ████║██╔════╝                   ",
    u8"                     ██║  ███╗███████║██╔████╔██║█████╗                     ",
    u8"                     ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝                     ",
    u8"                     ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗                   ",
    u8"                      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝                   ",
    u8"                                                                            ",
    u8"                         [ GAME ABOUT TO START ]                            ",
    u8"                                                                            ",
    u8"                         loading......wait  ....                            ",
    u8"                                                                            ",
};

void printStartBanner() {
    for (int i = 0; i < 12; i++) {
        cout << startBanner[i] << endl;
    }
}
// Ground layout
char ground[groundRowSize][groundColSize] =
    {
        "=============================================================================================",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "=                                                                                          =",
        "T                                                                                         T",
        "============================================================================================="};

// Player sprite
char player[playerRowSize][playerColSize] =
    {
        "  o  ",  // head
        " /|\\ ", // arms + body
        " / \\ "  // legs
};

// Allowed columns
int allowedCols[] = {20, 30, 40, 50, 60, 70};

// Drawing
void printground()
{
    for (int r = 0; r < groundRowSize; r++)
    {
        for (int c = 0; c < groundColSize; c++)
        {
            cout << ground[r][c];
        }
        cout << endl;
    }
}

void eraseplayer(int x, int y)
{
    for (int r = 0; r < playerRowSize; r++)
    {
        for (int c = 0; c < playerColSize; c++)
        {
            gotoxy(x + c, y + r);
            cout << " ";
        }
    }
}

void printPlayer()
{
    for (int r = 0; r < playerRowSize; r++)
    {
        for (int c = 0; c < playerColSize; c++)
        {
            gotoxy(pX + c, pY + r);
            cout << player[r][c];
        }
    }
}

// Movement
void movePlayerLeft()
{
    if (getCharAtxy(pX - 1, pY) == ' ')
    {
        eraseplayer(pX, pY);
        pX--;
        printPlayer();
    }
}

void movePlayerRight()
{
    if (getCharAtxy(pX + playerColSize, pY) == ' ')
    {
        eraseplayer(pX, pY);
        pX++;
        printPlayer();
    }
}

// Food
void generateFood()
{
    foodY = pY + playerRowSize - 1; // feet row
    int colIndex = rand() % (sizeof(allowedCols) / sizeof(allowedCols[0]));
    foodX = allowedCols[colIndex];
}

void printfood()
{
    gotoxy(foodX, foodY);
    cout << "F";
}
const char* greatBanner[] = {
    u8"                                         ",
    u8"                                         ",
    u8" ██████╗ ██████╗ ███████╗ █████╗ ████████╗ ",
    u8"██╔════╝ ██╔══██╗██╔════╝██╔══██╗╚══██╔══╝ ",
    u8"██║  ███╗██████╔╝█████╗  ███████║   ██║    ",
    u8"██║   ██║██╔═██║ ██╔══╝  ██╔══██║   ██║    ",
    u8"╚██████╔╝██║ ██║ ███████╗██║  ██║   ██║    ",
    u8" ╚═════╝ ╚═╝ ╚═╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ",
    u8"                                           ",
    u8"                 GREAT!                    "
};

void printGreatBanner() {
    for (int i = 0; i < 8; i++) {
        cout << greatBanner[i] << endl;
    }
}



void playergrowth()
{
    gotoxy(50, groundRowSize + 60);
    cout<<  "                    " <<endl;
    cout << "╔══════════════════╗" << endl;
    cout << "║      SCORE       ║" << endl;
    cout << "╠══════════════════╣" << endl;
    cout << "║       " << score <<  "         ║" << endl;
    cout << "╚══════════════════╝" << endl;
    cout<<  "                    " <<endl;
}

void gulpfood()
{
    gotoxy(foodX, foodY);
    cout << " "; // erase food
    score += 10;
    gotoxy(11, 1);              // move cursor near top-left (x=10, y=0)
    printGreatBanner(); 
    playergrowth();
    generateFood(); // new random position
    printfood();    // show new food
}

// Bomb
void printbomb()
{
    gotoxy(bombX, bombY);
    cout << "O";
}
const char *dumbBanner[] = {
    u8"                                         ",
    u8"██████╗  ██╗   ██╗ ███╗   ███╗ ██████╗   ",
    u8"██╔══██╗ ██║   ██║ ████╗ ████║ ██╔══██╗  ",
    u8"██║  ██║ ██║   ██║ ██╔████╔██║ ███████║  ",
    u8"██║  ██║ ██║   ██║ ██║╚██╔╝██║ ██║  ██║  ",
    u8"██╚███   ╚██████╔╝ ██║ ╚═╝ ██║ ██╚███    ",
    u8" ╚═══╝    ╚═════╝  ╚═╝     ╚═╝  ╚═══╝    ",
    u8"                                         ",
};

void printDumbBanner()
{
    for (int i = 0; i < 6; i++)
    {
        cout << dumbBanner[i] << endl;
    }
}

int main()
{
#

    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
    // system("chcp 65001 > nul"); // optional, but API is cleaner

    // ...

    system("cls");
    srand(time(0)); // seed random generator
    system("color 45");  
    gotoxy(60,9);
    printStartBanner();
      Sleep(1300);
      system("cls");
    printground();
    printPlayer();

    generateFood(); // first food
    printfood();
    printbomb(); // fixed bomb for now

    while (true)
    {
        if (GetAsyncKeyState(VK_LEFT))
        {
            system("color 60");
            movePlayerLeft();

            Sleep(50);
        }
        if (GetAsyncKeyState(VK_RIGHT))
        {
            system("color BF");
            movePlayerRight();
            Sleep(50);
        }

        // Collision with food (bounding box, allow edge contact)
        if (foodX >= pX && foodX <= pX + playerColSize &&
            foodY >= pY && foodY <= pY + playerRowSize)
        {
            gulpfood();
        }

        // Collision with bomb (bounding box)
        if (bombX >= pX && bombX <= pX + playerColSize &&
            bombY >= pY && bombY <= pY + playerRowSize)
        {
            system("cls");
            printground();
            gotoxy(15, groundRowSize - 15);
            system("color C8 ");
            printDumbBanner();
            gotoxy(30, groundRowSize + 30);
            cout << " BYE with  "<< score <<" \n ";
            Sleep(2000);
            system("cls");
            break;
        }
    }
}