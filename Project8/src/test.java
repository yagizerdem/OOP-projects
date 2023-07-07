import javax.xml.crypto.Data;
import java.io.FileReader;
import java.io.IOException;
import java.sql.SQLSyntaxErrorException;
import java.util.Scanner;

public class test {
    private Scanner scanner = new Scanner(System.in);

    public static void init() {
        HotelRooms.initializeHotelRooms();
        try {
            FileReader file = new FileReader("C:\\Users\\yagiz\\Desktop\\HotelManagement\\input.txt");
            Scanner Reader = new Scanner(file);
            while (Reader.hasNextLine()) {
                String data = Reader.nextLine();
                String[] commands = data.split(";");
                String operation = commands[0];
                if (operation.equals("addEmployee")) {
                    Phone phone = new Phone(90, Integer.parseInt(commands[4]));

                    int bday = Integer.parseInt(commands[5].split("/")[0]);
                    int bmonth = Integer.parseInt(commands[5].split("/")[1]);
                    int byear = Integer.parseInt(commands[5].split("/")[2]);

                    int bitirday = Integer.parseInt(commands[6].split("/")[0]);
                    int bitirmonth = Integer.parseInt(commands[6].split("/")[1]);
                    int bitiryear = Integer.parseInt(commands[6].split("/")[2]);

                    Date baslamatarhih = new Date(bday, bmonth, byear);
                    Date bitirmetarhi = new Date(bitirday, bitirmonth, bitiryear);
                    int baslama = Date.ConvertDatetoDay(baslamatarhih);
                    int bitirme = Date.ConvertDatetoDay(bitirmetarhi);
                    Employee employee = new Employee(commands[1], commands[2], Integer.parseInt(commands[3]), phone, baslama, bitirme);
                    employee.registerEmployee(employee);
                }
                if (operation.equals("listEmployee")) {
                    Employee.listEmployee();
                }
                if (operation.equals("removeEmployee")) {
                    Employee.removeEmployee(Integer.parseInt(commands[1]));
                }

                if (operation.equals("addCustomer")) {
                    Phone phone = new Phone(90, Integer.parseInt(commands[3]));
                    Customer.registerCustomer(new Customer(commands[1], commands[2], phone));
                }
                if (operation.equals("listCustomer")) {
                    Customer.listCustomer();
                }
                if (operation.equals("removeCustomer")) {
                    Customer.removeCustomer(Integer.parseInt(commands[1]));
                }
                if (operation.equals("addReservation")) {
                    String[] datearr = commands[3].split("/");
                    Date date = new Date(Integer.parseInt(datearr[0]), Integer.parseInt(datearr[1]), Integer.parseInt(datearr[2]));
                    Reservation reservation = new Reservation(Integer.parseInt(commands[1]), Integer.parseInt(commands[2]), date, Date.CalculateDate(date, Integer.parseInt(commands[4])));
                    Reservation.registerReservation(reservation);
                }
                if (operation.equals("listReservation")) {
                    Reservation.listReservation();
                }
                if (operation.equals("removeReservation")) {
                    Reservation.removeReservation(Integer.parseInt(commands[1]));
                }
                if (operation.equals("searchCustomer")) {
                    Customer.searchCustomer(commands[1]);
                }
                if (operation.equals(("serchReservation"))) {
                    String[] datearr = commands[1].split("/");
                    Date startdate = new Date(Integer.parseInt(datearr[0]), Integer.parseInt(datearr[1]), Integer.parseInt(datearr[2]));
                    String[] datearr2 = commands[2].split("/");
                    Date enddate = new Date(Integer.parseInt(datearr2[0]), Integer.parseInt(datearr2[1]), Integer.parseInt(datearr2[2]));

                    Reservation.searchReservation(startdate, enddate);
                }
                if (operation.equals("listRooms")) {
                    HotelRooms.listRooms();
                }
                if (operation.equals("showavailableRooms")) {
                    HotelRooms.listavailableRooms();
                }
                if (operation.equals("listProfit")) {
                    HotelRooms.listprofit();
                }
                if (operation.equals("selectedRoomprofit")) {
                    HotelRooms.selectedRoomprofit(Integer.parseInt(commands[1]));
                }
                if (operation.equals("listSalary")) {
                    Employee.listSalary();
                }
                if (operation.equals("selectedsalary")) {
                    Employee.selectedSalary(Integer.parseInt(commands[1]));
                }
                if (operation.equals("getcustomerscounteachday")) {
                        test.getcustomerscounteachday(new Date(Integer.parseInt(commands[1].split("/")[0]), Integer.parseInt(commands[1].split("/")[1]), Integer.parseInt(commands[1].split("/")[2])), new Date(Integer.parseInt(commands[2].split("/")[0]), Integer.parseInt(commands[2].split("/")[1]), Integer.parseInt(commands[2].split("/")[2])));
                }
                if(operation.equals("simulation")){
                    test.simulation(new Date(Integer.parseInt(commands[1].split("/")[0]), Integer.parseInt(commands[1].split("/")[1]), Integer.parseInt(commands[1].split("/")[2])), new Date(Integer.parseInt(commands[2].split("/")[0]), Integer.parseInt(commands[2].split("/")[1]), Integer.parseInt(commands[2].split("/")[2])));
                }

                if (operation.equals("-----")) {
                    System.out.println("-------------------");
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        //end of init method
    }

    public static void getcustomerscounteachday(Date startday, Date endday) {
        for (int i = 1; i <= 30; i++) {
            System.out.printf("day:%2d ", i);
        }
        System.out.println("\ncustomer amount:");
        int startdayscount = startday.day + (startday.month * 30) + ((startday.year - 2000) * 360);
        int enddayscount = endday.day + (endday.month * 30) + ((endday.year - 2000) * 360);
        int start = startday.day;

        Reservation[] list = Reservation.getList();
        for (int i = 0; i < enddayscount - startdayscount; i++) {
            int customercounter = 0;
            for (int j = 0; j < 30; j++) {
//                System.out.println(Date.ConvertDatetoDay(list[j].startdate));
//                System.out.println(startdayscount+i);
//                System.out.println(Date.ConvertDatetoDay(list[j].enddate));
//                System.out.println(enddayscount);
                if (list[j] != null && startdayscount+i > Date.ConvertDatetoDay(list[j].startdate) && startdayscount+i < Date.ConvertDatetoDay(list[j].enddate)) {
                    customercounter++;
                }
            }
            System.out.printf("day : %d customercount : %d \n",start++,customercounter);
        }

    }

    public static void simulation(Date startday, Date endday){
        for (int i = 1; i <= 30; i++) {
            System.out.printf("day:%2d ", i);
        }
        System.out.println("\nsatisfaction rate:");
        int startdayscount = startday.day + (startday.month * 30) + ((startday.year - 2000) * 360);
        int enddayscount = endday.day + (endday.month * 30) + ((endday.year - 2000) * 360);
        int start = startday.day;



        Reservation[] list = Reservation.getList();
        Employee[] emplist = Employee.getList();

        for (int i = 0; i < enddayscount - startdayscount; i++) {
            int customercounter = 0;
            int employeecount = 0;
            for (int j = 0; j < 30; j++) {
                if (list[j] != null && startdayscount+i > Date.ConvertDatetoDay(list[j].startdate) && startdayscount+i < Date.ConvertDatetoDay(list[j].enddate)) {
                    customercounter++;
                }
            }
            for (int k = 0; k <2 ; k++){
                if (startdayscount+i > emplist[k].gorevbaslama && startdayscount+i < emplist[k].gorevbitirme) {
                    employeecount++;
                }
            }
            float satisfaction = 0;
            if(customercounter<=employeecount){
                satisfaction = 100;
            }
            else{
                satisfaction = ((float) employeecount/(float)customercounter)*100;
            }

            System.out.printf("day : %d customercount :%d empcount : %d stisfaction_percentage :%f\n",start++,customercounter,employeecount,satisfaction);
        }

    }
}
