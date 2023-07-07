public class Date {
    int day ;
    int month;
    int year;
    Date(int day , int month , int year){
        this.day = day;
        this.month = month;
        this.year = year;
    }

    //implement this funciton
    public static Date CalculateDate(Date date , int days){
        int day = date.day;
        int month = date.month;
        int year = date.year;
        Date output = new Date(0,month,year);
        if(month == 2){
            if((day + days)>=28){
                output.day = (day+days)%28;
                output.month++;
            }else{
                output.day = day+days;
            }
        }
        else if(month ==1 || month==3 || month==5 || month == 7 || month ==8 || month == 10 || month == 12){
            if((day + days)>=31){
                output.day = (day+days)%31;
                output.month++;
            }else{
                output.day = day+days;
            }
        }
        else if(month ==4 || month==6 || month==9 || month == 11){
            if((day + days)>=30){
                output.day = (day+days)%30;
                output.month++;
            }else{
                output.day = day+days;
            }
        }
        if(output.month >12){
            output.month = 1;
        }
          return  output;
    }
    public static int ConvertDatetoDay(Date date){
        int result = 0;
        result+= date.day +(date.month*30)+((date.year-2000)*360);
        return  result;
    }
}
