public class Reservation {
    private static int idcounter = 0 ;
    int id;
    int customerid ;
    int roomid ;
    Date startdate;
    Date enddate;
    private static Reservation[] list = new Reservation[30];

    Reservation(int customerid , int roomid , Date startdate , Date enddate){
        this.id = ++idcounter;
        this.customerid = customerid;
        this.roomid = roomid;
        this.startdate = startdate;
        this.enddate = enddate;
    }
    public static void registerReservation(Reservation reservation) {
        list[idcounter - 1] = reservation;
        HotelRooms[] rooms = HotelRooms.getRooms();
        for (int i = 0; i < rooms.length; i++) {
            if(rooms[i].id == reservation.roomid){
                rooms[i].reserveddayscount += Date.ConvertDatetoDay(reservation.enddate) - Date.ConvertDatetoDay(reservation.startdate);
            }
        }
    }
    public static void listReservation() {
        int lenght = getListLenght();
        for (int i = 0; i < lenght; i++) {
            System.out.printf(" id: %d  customerid:%10d roomid:%10d startdate:%10d-%d-%d enddate:%10d-%d-%d \n", list[i].id, list[i].customerid, list[i].roomid , list[i].startdate.day,list[i].startdate.month,list[i].startdate.year , list[i].enddate.day,list[i].enddate.month,list[i].enddate.year);
        }
    }

    public static  void removeReservation(int id){
        Reservation[] temp = new Reservation[30];
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
    public static int getListLenght() {
        int lenght = 0;
        for (int i = 0; i < list.length; i++) {
            if (list[i] == null) break;
            lenght++;
        }
        return lenght;
    }

    public static void searchReservation(Date startdate , Date enddate){
        int start = Date.ConvertDatetoDay(startdate),end = Date.ConvertDatetoDay(enddate);
        for(int i = 0 ; i<list.length; i ++){
            if(list[i] != null){
                int reservedstart = Date.ConvertDatetoDay(list[i].startdate),reservedend = Date.ConvertDatetoDay(list[i].enddate);
                //System.out.println(start);System.out.println(end);System.out.println(reservedstart);System.out.println(reservedend);
                if(start<=reservedstart && reservedend<=end){
                    System.out.printf(" id: %d  customerid:%10d roomid:%10d startdate:%10d-%d-%d enddate:%10d-%d-%d \n", list[i].id, list[i].customerid, list[i].roomid , list[i].startdate.day,list[i].startdate.month,list[i].startdate.year , list[i].enddate.day,list[i].enddate.month,list[i].enddate.year);
                }
            }

        }
    }

    public static Reservation[] getList(){
        return list;
    }
}
