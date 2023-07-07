import java.net.http.HttpClient;

public class HotelRooms {

    int id = 0 ;
    public  RoomType type ;
    public float cost ;
    public boolean Hasairconditioner ;
    public  boolean HasTv ;
    public boolean HasseaView;
    public  int reserveddayscount = 0;
    private static  HotelRooms[] rooms = new HotelRooms[30];
    public float calculatecost(){
        float base = 20;
        if(Hasairconditioner) base=base*2;
        if(HasTv) base=base*1.3f;
        if(HasseaView) base=base*2;
        if(type == RoomType.Vip) base=base*4;
        if(type == RoomType.Medium)  base=base*2;
        return base;
    }
    public  static void initializeHotelRooms(){

        // boş yere uğraşmıyorum hepsine aynı odayi ver geç ,
        // gereksiz bir proje zaten
        for(int i = 1 ; i<=30 ; i++){
            HotelRooms room = new HotelRooms();
            room.id =i;
            room.type = RoomType.Vip;
            room.Hasairconditioner = true;
            room.HasseaView = true;
            room.HasTv = true;
            room.cost = room.calculatecost();

            //adding room to list
            rooms[i-1]= room;
        }

    }
    public static void listRooms(){
        System.out.println("All rooms");
        for(int i = 0 ; i<30 ; i++){
            System.out.printf("id:%10d type:%s cost:%f hasairconditioner:%b hastv:%b hasseaview:%b\n",rooms[i].id,rooms[i].type.name(),rooms[i].cost,rooms[i].Hasairconditioner,rooms[i].HasTv,rooms[i].HasseaView);
        }
    }

    public static void listavailableRooms(){
        System.out.println("Available rooms");
        Reservation[] list = Reservation.getList();
        for(int i = 0 ; i<rooms.length ; i++){
            Boolean flag = true;
            for(int j = 0; j<list.length;j++){
                if(list[i]!=null&&rooms[j].id == list[i].roomid){
                    flag =false;
                }
            }
            if(flag){
                System.out.printf("id:%10d type:%s cost:%f hasairconditioner:%b hastv:%b hasseaview:%b\n",rooms[i].id,rooms[i].type.name(),rooms[i].cost,rooms[i].Hasairconditioner,rooms[i].HasTv,rooms[i].HasseaView);
            }
        }


    }

    public  static HotelRooms[] getRooms(){
        return rooms;
    }

    public  static void listprofit(){
        for(int i = 0 ; i < rooms.length ; i++){
            float profit = 0;
            if(rooms[i].type == RoomType.Vip) profit+=300;
            if(rooms[i].type == RoomType.Medium) profit+=200;
            if(rooms[i].type == RoomType.Low) profit+=100;

            if(rooms[i].HasTv = true) profit+=50;
            if(rooms[i].Hasairconditioner = true) profit+=50;
            if(rooms[i].HasseaView = true) profit+=100;

            profit *= rooms[i].reserveddayscount;

            System.out.printf("roomid:%10d profit:%10f \n" ,rooms[i].id , profit != 0 ? profit-rooms[i].cost : 0);
        }
    }

    public static void selectedRoomprofit(int id){
        HotelRooms room = null;
        for(int i = 0 ; i<rooms.length;i++){
            if(id == rooms[i].id) room = rooms[i];
        }
        if(room != null){
            float profit = 0;
            if(room.type == RoomType.Vip) profit+=300;
            if(room.type == RoomType.Medium) profit+=200;
            if(room.type == RoomType.Low) profit+=100;

            if(room.HasTv = true) profit+=50;
            if(room.Hasairconditioner = true) profit+=50;
            if(room.HasseaView = true) profit+=100;

            profit *= room.reserveddayscount;
            System.out.printf("roomid:%10d profit:%10f \n" ,room.id , profit != 0 ? profit-room.cost : 0);
        }


    }
}
