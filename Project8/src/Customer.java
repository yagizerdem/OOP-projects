public class Customer {
    private static int idcounter = 0;
    public int id;
    public String Name;
    public String Surname;
    public Phone phone;
    private static Customer[] list = new Customer[30];

    Customer(String name, String surname, Phone phone) {
        this.id = ++idcounter;
        this.Name = name;
        this.Surname = surname;
        this.phone = phone;
    }

    Customer() {
    }

    public static void registerCustomer(Customer customer) {
        list[idcounter - 1] = customer;
    }

    public static void listCustomer() {
        for (int i = 0; i < getListLenght(); i++) {
            System.out.printf(" id: %d  name:%10s surname:%s phonenumber:%d  \n", list[i].id, list[i].Name, list[i].Surname, list[i].phone.Number);
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

    public static void removeCustomer(int id) {
        Customer[] temp = new Customer[30];
        int lenght = getListLenght();
        for (int i = 0; i < lenght; i++) {
            if (list[i].id < id) {
                temp[i] = list[i];
            } else if (list[i].id == id) {
            } else {
                list[i].id--;
                temp[i - 1] = list[i];
            }

        }
        list = temp;
    }

    // implement method later
    public static void searchCustomer(String pattern) {

        //end of method
    }

}