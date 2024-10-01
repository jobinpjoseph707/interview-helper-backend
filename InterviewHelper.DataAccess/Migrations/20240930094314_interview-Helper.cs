using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InterviewHelper.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class interviewHelper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "ExperienceLevels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ApplicationRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "ApplicationRoleId", "ExperienceLevelId", "IsActive", "TechnologyId", "Text" },
                values: new object[,]
                {
                    { 1, 1, 2, true, 1, "What is Angular Dependency Injection?" },
                    { 2, 1, 2, true, 1, "Explain Angular Component Lifecycle." },
                    { 3, 1, 2, true, 1, "How does Change Detection work in Angular?" },
                    { 4, 1, 2, true, 1, "What are Angular Services?" },
                    { 5, 1, 2, true, 1, "Explain Angular Pipes." },
                    { 6, 1, 2, true, 1, "What is NgZone in Angular?" },
                    { 7, 1, 2, true, 1, "What is the difference between ngIf and hidden in Angular?" },
                    { 8, 1, 2, true, 1, "What are Angular Directives?" },
                    { 9, 1, 2, true, 1, "Explain how Angular CLI works." },
                    { 10, 1, 2, true, 1, "How do you optimize performance in Angular?" },
                    { 11, 1, 1, true, 2, "What is JSX in React?" },
                    { 12, 1, 1, true, 2, "Explain React Components." },
                    { 13, 1, 1, true, 2, "What are React Hooks?" },
                    { 14, 1, 1, true, 2, "What is the Virtual DOM in React?" },
                    { 15, 1, 1, true, 2, "How do you handle events in React?" },
                    { 16, 1, 1, true, 2, "What is a React Fragment?" },
                    { 17, 1, 1, true, 2, "What are Props in React?" },
                    { 18, 1, 1, true, 2, "How does state management work in React?" },
                    { 19, 1, 1, true, 2, "What are Higher-Order Components in React?" },
                    { 20, 1, 1, true, 2, "What is the difference between state and props?" },
                    { 21, 1, 3, true, 7, "What is hoisting in JavaScript?" },
                    { 22, 1, 3, true, 7, "Explain closures in JavaScript." },
                    { 23, 1, 3, true, 7, "What is event delegation in JavaScript?" },
                    { 24, 1, 3, true, 7, "How do JavaScript Promises work?" },
                    { 25, 1, 3, true, 7, "What is the event loop in JavaScript?" },
                    { 26, 1, 3, true, 7, "What is the difference between let and var?" },
                    { 27, 1, 3, true, 7, "How does async/await work in JavaScript?" },
                    { 28, 1, 3, true, 7, "What is a JavaScript module?" },
                    { 29, 1, 3, true, 7, "Explain JavaScript destructuring." },
                    { 30, 1, 3, true, 7, "What is the Temporal Dead Zone in JavaScript?" },
                    { 31, 1, 1, true, 3, "What is Vue.js?" },
                    { 32, 1, 1, true, 3, "Explain Vue.js Components." },
                    { 33, 1, 1, true, 4, "What is Svelte?" },
                    { 34, 1, 1, true, 4, "Explain Svelte's reactivity model." },
                    { 35, 1, 1, true, 5, "Explain the key features of Java." },
                    { 36, 1, 1, true, 5, "What are Java streams?" },
                    { 37, 1, 1, true, 6, "What is the purpose of Rust’s ownership model?" },
                    { 38, 1, 1, true, 6, "Explain Rust’s memory safety." },
                    { 39, 1, 2, true, 8, "What is functional programming?" },
                    { 40, 1, 2, true, 8, "Explain higher-order functions in functional programming." },
                    { 41, 1, 2, true, 3, "What are Vue Directives?" },
                    { 42, 1, 2, true, 3, "How does Vue.js handle state management?" },
                    { 43, 1, 3, true, 3, "Explain Vue Router and its usage." },
                    { 44, 1, 3, true, 3, "What is Vuex and how does it work?" },
                    { 45, 1, 2, true, 4, "What is the Svelte Store?" },
                    { 46, 1, 2, true, 4, "How do you handle forms in Svelte?" },
                    { 47, 1, 3, true, 4, "Explain the reactivity mechanism in Svelte." },
                    { 48, 1, 3, true, 4, "How do transitions and animations work in Svelte?" },
                    { 49, 1, 2, true, 5, "What is the difference between HashMap and Hashtable?" },
                    { 50, 1, 2, true, 5, "Explain Java garbage collection." },
                    { 51, 1, 3, true, 5, "What is the significance of the `volatile` keyword in Java?" },
                    { 52, 1, 3, true, 5, "Explain how memory management works in Java." },
                    { 53, 1, 2, true, 6, "What is the borrow checker in Rust?" },
                    { 54, 1, 2, true, 6, "How do Rust traits work?" },
                    { 55, 1, 3, true, 6, "Explain the difference between `Box`, `Rc`, and `Arc` in Rust." },
                    { 56, 1, 3, true, 6, "How does Rust ensure memory safety without garbage collection?" },
                    { 57, 1, 3, true, 8, "What is the significance of immutability in functional programming?" },
                    { 58, 1, 3, true, 8, "Explain how recursion is handled in functional programming." },
                    { 59, 1, 1, true, 9, "What is the difference between a list and a tuple in Python?" },
                    { 60, 1, 1, true, 9, "What are Python decorators?" },
                    { 61, 1, 2, true, 9, "Explain how list comprehensions work in Python." },
                    { 62, 1, 2, true, 9, "What is a generator in Python?" },
                    { 63, 1, 3, true, 9, "Explain Python's Global Interpreter Lock (GIL)." },
                    { 64, 1, 3, true, 9, "How does memory management work in Python?" },
                    { 65, 1, 1, true, 10, "What is the difference between value type and reference type in C#?" },
                    { 66, 1, 1, true, 10, "Explain how exception handling works in C#." },
                    { 67, 1, 2, true, 10, "What are C# delegates?" },
                    { 68, 1, 2, true, 10, "What is LINQ in C#?" },
                    { 69, 1, 3, true, 10, "Explain async/await in C# and how it compares to other languages." },
                    { 70, 1, 3, true, 10, "How does garbage collection work in C#?" },
                    { 71, 1, 1, true, 1, "What is Angular's Dependency Injection?" },
                    { 72, 1, 1, true, 1, "How do you create reusable components in Angular?" },
                    { 73, 1, 3, true, 1, "What is Angular Universal and how does it handle server-side rendering?" },
                    { 74, 1, 3, true, 1, "How do you optimize the performance of an Angular application?" },
                    { 75, 1, 2, true, 2, "What is the use of `useEffect` in React?" },
                    { 76, 1, 2, true, 2, "Explain how React handles state with `useState`." },
                    { 77, 1, 3, true, 2, "What is React Server Components?" },
                    { 78, 1, 3, true, 2, "Explain Context API in React and how it is used." },
                    { 79, 1, 1, true, 7, "What are JavaScript data types?" },
                    { 80, 1, 1, true, 7, "Explain the difference between `var`, `let`, and `const` in JavaScript." },
                    { 81, 1, 2, true, 7, "Explain how `async` and `await` work in JavaScript." },
                    { 82, 1, 2, true, 7, "What are JavaScript Promises and how are they used?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 82);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "ExperienceLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ApplicationRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
