# VBC - Visual Basic Calculator

A Windows Forms calculator application built with Visual Basic .NET for learning purposes.

## ?? Features

- **Basic Arithmetic Operations**: Addition (+), Subtraction (-), Multiplication (*), and Division (/)
- **User-Friendly Interface**: Windows Forms GUI with intuitive button layout
- **Calculation History**: SQLite database integration to store and view calculation history
- **Error Handling**: Built-in validation for division by zero and invalid inputs
- **Delete & Clear Functions**: Backspace functionality and complete reset options

## ??? Technologies Used

- **Language**: Visual Basic .NET
- **Framework**: .NET 9.0 Windows Forms
- **Database**: SQLite with System.Data.SQLite package
- **UI Framework**: Windows Forms

## ?? Requirements

- .NET 9.0 or later
- Windows operating system
- Visual Studio 2022 (recommended) or any compatible IDE

## ?? Installation

1. **Clone the repository**:git clone <repository-url>
   cd VB_Calc
2. **Restore NuGet packages**:dotnet restore
3. **Build the project**:dotnet build
4. **Run the application**:dotnet run
## ?? Project Structure
VB_Calc/
??? Main.vb                 # Main calculator form and logic
??? Main.Designer.vb        # UI design for main form
??? History.vb              # History window functionality
??? History.Designer.vb     # UI design for history window
??? Database.vb             # SQLite database operations
??? VB_Calc.vbproj         # Project file
??? README.md              # This file
## ?? How to Use

1. **Basic Calculations**:
   - Click number buttons (0-9) to input numbers
   - Use operation buttons (+, -, *, /) for arithmetic operations
   - Press the equals button (=) to get the result

2. **Additional Functions**:
   - **Delete**: Remove the last entered digit
   - **Clear**: Reset the calculator completely
   - **History**: View previous calculations stored in the database

3. **History Feature**:
   - All calculations are automatically saved to a local SQLite database
   - Click the "History" button to view past calculations
   - History displays the operation and result in a data grid

## ??? Architecture

### Main Components

- **Main.vb**: Contains the core calculator logic with:
  - Number and operation button handlers
  - Calculation engine using lambda functions
  - Database integration for history storage
  - Error handling for edge cases

- **Database.vb**: Manages SQLite operations:
  - Creates history table on startup
  - Stores calculation results
  - Retrieves history data for display

- **History.vb**: Displays calculation history in a DataGridView

### Key Features Implementation

- **Operations Dictionary**: Uses lambda functions for cleaner arithmetic operations
- **State Management**: Tracks current numbers and operations during calculation flow
- **Input Validation**: Prevents invalid operations like division by zero
- **Decimal Support**: Handles decimal point input with validation

## ?? Code Highlights

### Functional Programming ApproachDim operations As New Dictionary(Of String, Func(Of Double, Double, Double)) From
{
    {"+", Function(x As Double, y As Double) x + y},
    {"-", Function(x As Double, y As Double) x - y},
    {"*", Function(x As Double, y As Double) x * y},
    {"/", Function(x As Double, y As Double) If(y <> 0 AndAlso x <> 0, x / y, Double.NaN)}
}
### Database Integration
- Automatic SQLite database creation
- Parameterized queries for security
- Real-time history saving

## ?? Learning Objectives

This project demonstrates:
- Visual Basic .NET Windows Forms development
- Event-driven programming concepts
- Database integration with SQLite
- Error handling and input validation
- Object-oriented programming principles
- State management in GUI applications

## ?? Future Enhancements

- [ ] Scientific calculator functions (sin, cos, tan, etc.)
- [ ] Memory functions (M+, M-, MC, MR)
- [ ] Keyboard input support
- [ ] Export history to CSV/Excel
- [ ] Themes and customization options
- [ ] Unit conversion features

## ?? Known Issues

- Division by zero displays "NaN" instead of a user-friendly error message
- History database path is hardcoded
- No keyboard shortcuts implemented

## ?? Contributing

This is a learning project, but suggestions and improvements are welcome! Feel free to:
- Report bugs
- Suggest new features
- Submit pull requests
- Share learning resources

## ?? License

This project is for educational purposes. Feel free to use and modify as needed for learning.

---

**Note**: This calculator was built as a learning exercise to understand Visual Basic .NET and Windows Forms development.
