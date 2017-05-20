<%@page contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>
<%@page import="guest.*"%>
 
<jsp:useBean id="guestDao" type="guest.GuestDao" scope="request" />
 
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
    "http://www.w3.org/TR/html4/loose.dtd">
 
<html>
    <head>
        <title>JPA Guestbook Web Application Tutorial</title>
    </head>
 
    <body>
        <form method="POST" action="guest.html">
            Name: <input type="text" name="name" />
            Number : <input type="text" name="number" /> <!--add extra input in form for room number and name it number -->
            <input type="submit" value="Add" />
        </form>
 
        <hr><ol> 
        <% for (Guest guest : guestDao.getAllGuests()) { %>
            <li> <%= guest.toString() %> </li> <!-- go through all list of guest and call toString method to get string -->
        <% }
 
        %>
          
        </ol>
        <!-- get list of guests and get list size-->
Total number of guests : <%= guestDao.getAllGuests().size()%> 
<hr>
      
            
       
 
		
	</body>
</html>