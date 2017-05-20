package guest;
 
import java.io.Serializable;
import java.sql.Date;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
 
@Entity
public class Guest implements Serializable {
    private static final long serialVersionUID = 1L;
 
    // Persistent Fields:
    @Id @GeneratedValue
    Long id;
    private String name;
    private Date signingDate;
    private String number; //add new variable to represent number
 
    // Constructors:
    public Guest() {
    }
 
    //constructor to take 2 parameter
    public Guest(String name, String number) {
        this.name = name;
        this.signingDate = new Date(System.currentTimeMillis());
        this.number = number; //set number vairable to 2nd argument (number)
    }
 
    // String Representation:
    @Override
    public String toString() {
        return name + " (signed on " + signingDate + ") Room " + number;
    }
}