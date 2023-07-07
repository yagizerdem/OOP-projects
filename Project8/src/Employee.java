import java.util.Date;

public class Employee {
    private static int idcounter = 0;
    public int id;
    public String Name; //required in input file
    public String Surname; //required in input file
    public int Salary; //required in input file
    public  Phone phone;
    private static Employee[] list = new Employee[30];

    public int gorevbaslama ;
    public int gorevbitirme ;
    Employee(String name, String surname, int salary, Phone phone ,int gorevbaslama ,int gorevbitirme) {
        this.id = ++idcounter;
        this.Name = name;
        this.Surname = surname;
        this.Salary = salary;
        this.phone = phone;
        this.gorevbaslama = gorevbaslama;
        this.gorevbitirme = gorevbitirme;
    }

    Employee() {
    }

    ;

    public static void registerEmployee(Employee employee) {
        Employee.list[idcounter - 1] = employee;
    }

    public static void listEmployee() {
        for (int i = 0; i < getListLenght(); i++) {
            System.out.printf(" id: %d  name:%10s surname:%s salary:%10d phonenumber:%d\n", list[i].id, list[i].Name, list[i].Surname, list[i].Salary,list[i].phone.Number);
        }
    }

    private static int getListLenght() {
        int lenght = 0;
        for (int i = 0; i < list.length; i++) {
            if (list[i] == null) break;
            lenght++;
        }
        return lenght;
    }

    public static  void removeEmployee(int id){
        Employee[] temp = new Employee[30];
        int lenght = getListLenght();
        for(int i = 0 ; i<lenght;i++){
            if(list[i].id < id){
                temp[i] = list[i];
            }
            else if(list[i].id == id){}
            else{
                list[i].id--;
                temp[i-1] = list[i];
            }

        }
        list =temp;
    }
    public  static void listSalary(){
        for (int i = 0; i < list.length; i++) {
            if (list[i] != null){
                System.out.printf("employeeid:%d Employeename:%s salary:%d \n",list[i].id,list[i].Name,list[i].Salary);
            }
        }
    }
    public static void selectedSalary(int id){
        Employee employee = null;
        for (int i = 0; i<30 ; i++){
            if(list[i].id == id){
                employee = list[i];break;
            }
        }
        if(employee != null){
            System.out.printf("employeeid:%d Employeename:%s salary:%d \n",employee.id,employee.Name,employee.Salary);
        }

    }

    public static Employee[] getList(){
        return list;
    };
}
