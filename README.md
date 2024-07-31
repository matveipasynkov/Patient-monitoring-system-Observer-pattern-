# Patient monitoring system (Observer pattern)
This is my sixth project, which was assigned as homework in university. The console application is stored in ConsoleApp, the class library in Library.
### Main assignment
### Requirements for the class library
The class library must contain:
1) MyType classes (the name MyType is a stub and should be replaced by you with a more appropriate name for each class, based on your understanding of the data from the file
job) represent the objects described in the JSON file of the job. Nested and related objects are described by separate
classes. The fields of each class must be readable but closed to writing. Classes must contain a constructor to initialize their
fields. In addition to the fields described by the JSON file, classes must implement a ToJSON method that provides a string representation of the current object in JSON format. Choose independently
identifier (name) for the class, so that it logically describes the object and satisfies Microsoft naming rules.
3) All MyType classes implement the EventHandler<EventArgs> Updated event, which is responsible for notifying subscribers about changes to the object. Implement an inheritor class
EventArgs that stores the date and time of the changes.
4) AutoSaver class subscribed to Updated events of objects from JSON file. When receiving two events no more than 15 seconds apart, it should write the current
state of the collection of objects in JSON new file <original_json_file_name>_tmp.json
5) Class implementations must not violate data encapsulation and the Single Responsibility Principle.
6) Hierarchies should not violate the Liskov Substitution Principle and are designed based on the Dependency Inversion Principle.
Inversion Principle.) Architectural Principles (https://learn.microsoft.com/ru-ru/dotnet/architecture/modernweb-apps-azure/architectural-principles)
7) Class implementations should not violate encapsulation and relations defined between types, e.g., provide external references to fields or change the state of an object without checks.
without checking.
8) Library classes must be accessible outside the assembly.
9) Each non-static class (if any) must necessarily contain, among others,
a parameterless constructor or equivalent descriptions that allow its direct or
implicit invocation.
10) It is forbidden to modify the dataset for classes that are based on JSON representations from the assignment (e.g., adding fields not contained in the JSON representation).
in the JSON representation).
11) It is allowed to extend open behavior or add closed functional
members of the class.
12) It is allowed to use your own (self-descriptive) class hierarchies in addition to the ones
proposed in the assignment, also in compliance with OOP principles.
### Requirements for console application
The console application uses the class library described above and, with the help of the standard library System.Text.Json, receives data to form objects of type
MyType. Other JSON serialization options are not allowed in this task. The data for the objects, as well as the connection type between them, are extracted from the JSON representation of the file
of the job. The collection type for the objects should be chosen independently. 
#### The application must implement a menu that allows the user to:
1. Pass the file path to read and write data.
2. sort the collection of objects by one of the fields (not including nested objects).
3. Select an object and edit any field in it, except identifiers (fields that have “Id” in their name) and fields that change as a result of activation and
event processing. The user input must be processed correctly and, in case of incorrect input, it must be requested again.
