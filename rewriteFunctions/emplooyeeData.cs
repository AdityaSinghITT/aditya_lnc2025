class Employee
{
    private:
        int id;
        string name;
        string department;
        bool working;

    public:
        bool isWorking()
        {
            return working;
        }

        void terminate()
        {
            working = false;
        }
};

class EmployeeStorage
{
    public:
        void save(Employee employee);
};

class EmployeeReport
{
public:
    void printXML(Employee employee);
    void printCSV(Employee employee);
};