/*Section 1: Data Definition*/
	create table flights (
		flight_id int,
		departure_time datetime not null,
		arrival_time datetime not null,
		status varchar(9),
		origin_airport_id int,
		destination_airport_id int,
		airline_id int,
		constraint PK_flights primary key(flight_id),
		constraint FK_airport_origins foreign key(origin_airport_id) references airports(airport_id),
		constraint FK_airport_destinations foreign key(destination_airport_id) references airports(airport_id),
		constraint FK_airlines foreign key(airline_id) references airlines(airline_id),
		constraint CHK_flight_status check (status = 'Departing' or status = 'Delayed' or  status = 'Arrived' or  status = 'Cancelled')
	);

	create table tickets (
		ticket_id int,
		price decimal(8, 2) not null,
		class varchar(6),
		seat varchar(5) not null,
		customer_id int,
		flight_id int,
		constraint PK_tickets primary key(ticket_id),
		constraint FK_customers foreign key(customer_id) references customers(customer_id),
		constraint FK_flights foreign key(flight_id) references flights(flight_id),
		constraint CHK_ticket_class check (class = 'First' or class = 'Second' or  class = 'Third')
	);
	/*
	ticket_id	Integer from 1 to 2,147,483,647.	Primary Key
	price	Decimal with length of 8, 2 digits after the decimal point.	Null is not permitted.
	class	A string containing a maximum of 6 characters. Unicode is NOT needed.	Should only contain one of the following values:  ‘First’, ‘Second’, ‘Third’.
	seat	A string containing a maximum of 5 characters. Unicode is NOT needed.	Null is not permitted.
	customer_id	Integer from  1 to 2,147,483,647	Relationship with table customers.
	flight_id	Integer from 1 to 2,147,483,647	Relationship with table flights.

	*/



/*Section 2: Database Manipulations*/
/*Task 1: Data Insertion*/
	insert into flights(flight_id,	departure_time,	arrival_time,	status,	origin_airport_id,	destination_airport_id,	airline_id)
	values
	(1, STR_TO_DATE('13/10/2016 06:00 AM', '%d/%m/%Y %h:%i %p'), STR_TO_DATE('13/10/2016 10:00 AM', '%d/%m/%Y %h:%i %p'),	'Delayed', 1, 4, 1),
	(2, STR_TO_DATE('12/10/2016 12:00 PM', '%d/%m/%Y %h:%i %p'), STR_TO_DATE('12/10/2016 12:01 PM', '%d/%m/%Y %h:%i %p'),	'Departing', 1, 3, 2),
	(3, STR_TO_DATE('14/10/2016 03:00 PM', '%d/%m/%Y %h:%i %p'), STR_TO_DATE('20/10/2016 04:00 AM', '%d/%m/%Y %h:%i %p'),	'Delayed', 4, 2, 4),
	(4, STR_TO_DATE('12/10/2016 01:24 PM', '%d/%m/%Y %h:%i %p'), STR_TO_DATE('12/10/2016 4:31 PM' , '%d/%m/%Y %h:%i %p'),	'Departing', 3, 1, 3),
	(5, STR_TO_DATE('12/10/2016 08:11 AM', '%d/%m/%Y %h:%i %p'), STR_TO_DATE('12/10/2016 11:22 PM', '%d/%m/%Y %h:%i %p'),	'Departing', 4, 1, 1),
	(6, STR_TO_DATE('21/06/1995 12:30 PM', '%d/%m/%Y %h:%i %p'), STR_TO_DATE('22/06/1995 08:30 PM', '%d/%m/%Y %h:%i %p'),	'Arrived', 2, 3, 5),
	(7, STR_TO_DATE('12/10/2016 11:34 PM', '%d/%m/%Y %h:%i %p'), STR_TO_DATE('13/10/2016 03:00 AM', '%d/%m/%Y %h:%i %p'),	'Departing', 2, 4, 2),
	(8, STR_TO_DATE('11/11/2016 01:00 PM', '%d/%m/%Y %h:%i %p'), STR_TO_DATE('12/11/2016 10:00 PM', '%d/%m/%Y %h:%i %p'),	'Delayed', 4, 3, 1),
	(9, STR_TO_DATE('01/10/2015 12:00 PM', '%d/%m/%Y %h:%i %p'), STR_TO_DATE('01/12/2015 01:00 AM', '%d/%m/%Y %h:%i %p'),	'Arrived', 1, 2, 1),
	(10,STR_TO_DATE('12/10/2016 07:30 PM', '%d/%m/%Y %h:%i %p'),  STR_TO_DATE('13/10/2016 12:30 PM','%d/%m/%Y %h:%i %p'),	'Departing', 2, 1, 7);


	insert into tickets(ticket_id, price, class, seat, customer_id,	flight_id)
	values
	(1,	3000.00, 'First', '233-A', 3, 8),
	(2,	1799.90, 'Second', '123-D', 1, 1),
	(3,	1200.50, 'Second', '12-Z', 2, 5),
	(4,	410.68, 'Third', '45-Q', 2, 8),
	(5,	560.00, 'Third', '201-R', 4, 6),
	(6,	2100.00, 'Second', '13-T', 1, 9),
	(7,	5500.00, 'First', '98-O', 2, 7);

/*Task 2: Update Arrived Flights*/
	update flights
	set airline_id = 1
	where status = 'Arrived';
	/*Update all flights with status-‘Arrived’ Airline ID, to 1.*/

/*Task 3: Update Tickets*/
	update tickets t
	inner join flights f on t.flight_id = f.flight_id
	inner join airlines a on a.airline_id = f.airline_id
	set t.price = t.price * 1.5
	where a.rating = (select max(a.rating) from airlines a);

/*Find the highest-rated Airline, and increase all of its Flights’ Tickets’ prices with 50%.*/

/*Task 4: Table Creation*/
	create table customer_reviews(
		review_id int,
		review_content	varchar(255) not null,
		review_grade int,
		airline_id int,
		customer_id	int,
		constraint PK_customer_reviews primary key(review_id),
		constraint FK_customer_reviews_airlines foreign key(airline_id) references airlines(airline_id),
		constraint FK_customer_reviews_customers foreign key(customer_id) references customers(customer_id),
		constraint CHK_review_grade check (review_grade between 0 and 10)
	);

	create table customer_bank_accounts(
		account_id int,
		account_number	varchar(10) not null unique,
		balance decimal(10, 2) not null,
		customer_id	int,
		constraint PK_customer_bank_accounts_customer_bank_accounts primary key(account_id),
		constraint FK_customer_bank_accounts_customers foreign key(customer_id) references customers(customer_id)
	);
	/*

	The Tickets in the AMS are bought trough bank accounts, and your employers have decided that they need to track that too. You need to add a table that holds data about the Customers’ Bank Accounts. Add to the database a table called customer_bank_accounts. Here is what you need to have in it:
	customer_bank_accounts
	Column Name	Data Type	Constraints
	account_id	Integer from 1 to 2,147,483,647.	Primary Key
	account_number	A string containing a maximum of 10 characters. Unicode is NOT needed.	Null is not permitted.
	Needs to be unique.
	balance	Decimal with length of 10, 2 digits after the decimal point.	Null is not permitted.
	customer_id	Integer from 1 to 2,147,483,647.	Relationship with table customers.
	*/

/*Task 5: Fill the new Tables with Data*/
	insert into customer_reviews(review_id,	review_content,	review_grade,	airline_id,	customer_id)
	values
	(1,	'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
	(2,	'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
	(3,	'Meh...', 5, 4, 3),
	(4,	'Well I\'ve seen better, but I\'ve certainly seen a lot worse...', 7, 3, 5);



	insert into customer_bank_accounts(account_id, account_number, balance, customer_id)
	values
	(1, '123456790', 2569.23, 1),
	(2, '18ABC23672', 14004568.23, 2),
	(3, 'F0RG0100N3', 19345.20, 5);


/*Section 3: Querying*/
/*Task 1: Extract All Tickets*/
	select ticket_id, price, class, seat
	from tickets
	order by ticket_id;

	/*Task 1: Extract All Tickets
	Extract from the database, all of the Tickets, taking only
	 the Ticket’s ID, Price, Class and Seat. Sort the results ascending by Ticket ID.
	 @@@
	*/

/*Task 2: Extract All Customers */
	select customer_id, concat(first_name,' ', last_name) as full_name, gender
	from customers
	order by full_name, customer_id;

	/*
	Extract from the database, all of the Customers, 
	taking only the Customer’s ID, Full Name (First name + Last name separated by a single space) and Gender. 
	Sort the results by alphabetical order of the full name, and as second criteria, sort them ascending by Customer ID.

	@@@
	*/

/*Task 3: Extract Delayed Flights */
	select flight_id, departure_time, arrival_time
	from flights
	where status = 'Delayed';

	/*
	Task 3: Extract Delayed Flights 
	Extract from the database, all of the Flights, which have status-‘Delayed’,
	 taking only the Flight’s ID, Departure Time and Arrival Time. 
	 Sort the results ascending by Flight ID.

	@@@
	*/

/*Task 4: Extract Top 5 Most Highly Rated Airlines which have any Flights*/
	select distinct a.airline_id, a.airline_name, a.nationality, a.rating
	from airlines a
	inner join flights f on f.airline_id = a.airline_id

	order by a.rating desc /*(select max(a1.rating) from airlines a1 order by a1.airline_id)*/
	limit 5;
	/*
	Task 4: Extract Top 5 Most Highly Rated Airlines which have any Flights
	Extract from the database, the top 5 airlines, in terms of highest rating, 
	which have any flights, taking only the Airlines’ IDs and Airlines’ Names, 
	Airlines’ Nationalities and Airlines’ Ratings. 
	If two airlines have the same rating order them, ascending, by Airline ID.

	@@@
	$$$$$$$$$
	*/

/*Task 5: Extract all Tickets with price below 5000, for First Class*/
	select t.ticket_id, a.airport_name, concat(cu.first_name, ' ', cu.last_name) as full_name
	from tickets t
	inner join flights f on f.flight_id = t.flight_id
	inner join airports a on a.airport_id = f.destination_airport_id
	inner join customers cu on cu.customer_id = t.customer_id
	where t.price < 5000 and t.class = 'First'
	order by t.ticket_id;


	/*
	Task 5: Extract all Tickets with price below 5000, for First Class

	Extract from the database, all tickets, which have price below 5000, 
	and have class – ‘First´, taking the Tickets’ IDs, Flights’ 
	Destination Airport Name, and Owning Customers’ Full Names
	 (First name + Last name separated by a single space)
	 . Order the results, ascending, by Ticket ID.
	ticket_id	destination	customer_name
	1	Royals Airport	Zack Cody


	@@@
	$$$$$$$
	*/

/*Task 6: Extract all Customers which are departing from their Home Town*/
	select cu.customer_id, concat(cu.first_name, ' ', cu.last_name) as full_name, t.town_name
	from customers cu
	inner join tickets ti on ti.customer_id = cu.customer_id
	inner join flights f on f.flight_id = ti.flight_id
	inner join airports a on a.airport_id = f.origin_airport_id
	inner join towns t on t.town_id = cu.home_town_id
	where f.status = 'Departing' and a.town_id = cu.home_town_id
	order by cu.customer_id;
	/*
	task 6
	Extract from the database, all of the Customers, which are departing from their Home Town,
	 taking only the Customer’s ID, Full Name (First name + Last name separated by a single space)
	  and Home Town Name. Order the results, ascending, by Customer ID.
	customer_id	full_name	home_town
	2	Jonathan Half	Moscow

	@@@
	$$$$$
	*/

/*Task 7: Extract all Customers which will fly*/
	select distinct cu.customer_id, concat(cu.first_name, ' ', cu.last_name) as full_name, 2016 - year(cu.date_of_birth)
	from customers cu
	inner join tickets ti on ti.customer_id = cu.customer_id
	inner join flights f on f.flight_id = ti.flight_id
	where f.status = 'Departing';

	/*
	Task 7: Extract all Customers which will fly
	Extract from the database all customers, which have bought tickets and
	 the flights to their tickets have Status-‘Departing’, taking only the
	  Customer’s ID, Full Name (First name + Last name separated by a single space) and Age.
	   Order them Ascending by their Age. Assume that the current year is 2016. 
		If two people have the same age, order them by Customer ID, ascending. 

	customer_id	full_name	age
	2	Jonathan Half	33


	@@@@
	$$$
	*/

/*Task 8: Extract Top 3 Customers which have Delayed Flights*/
	select cu.customer_id, concat(cu.first_name, ' ', cu.last_name) as full_name, t.price as ticket_price, a.airport_name  as destination
	from customers cu
	inner join tickets t on cu.customer_id = t.customer_id 
	inner join flights f on t.flight_id = f.flight_id
	inner join airports a on a.airport_id = f.destination_airport_id
	where f.status = 'Delayed'
	order by t.price desc, cu.customer_id
	limit 3;


	/*
	8: Extract Top 3 Customers which have Delayed Flights
	Extract from the database, the top 3 Customers, in terms of most expensive Ticket,
	 which’s flights have Status- ‘Delayed’. Take the Customers’ IDs,
	  Full Name (First name + Last name separated by a single space), 
	  Ticket Price and Flight Destination Airport Name. 
	   If two tickets have the same price, order them, ascending, by Customer ID.
	customer_id	full_name	ticket_price	destination
	3	Zack Cody	3000.00	Royals Airport
	1	Cassidy Isacc	1799.90	Moscow Central Airport
	2	Jonathan Half	410.68	Royals Airport


	@@@
	$$$
	*/

/*Task 9: Extract the Last 5 Flights, which are departing.*/
	select f.flight_id, f.departure_time, f.arrival_time, a.airport_name, a_dest.airport_name
	from flights f
	inner join airports a on f.origin_airport_id = a.airport_id 
	inner join airports a_dest on f.destination_airport_id = a_dest.airport_id
	where f.status = 'Departing'
	order by f.departure_time, f.flight_id
	limit 5;

	/*
	Task 9: Extract the Last 5 Flights, which are departing.
	Extract from the database, the last 5 Flights, in terms of departure time, which have a status of ‘Departing’,
	 taking only the Flights’ IDs, Departure Time, Arrival Time, Origin and Destination Airport Names.
	You have to take the last 5 flights in terms of departure time, which means they must be ordered ascending by
	 departure time in the first place. If two flights have the same departure time, order them by Flight ID, ascending.
	flight_id	departure_time	arrival_time	origin	destination
	5	2016-10-12 08:11:00.000	2016-10-12 23:22:00.000	Moscow Central Airport	Sofia International Airport
	2	2016-10-12 12:00:00.000	2016-10-12 12:01:00.000	Sofia International Airport	Royals Airport
	4	2016-10-12 13:24:00.000	2016-10-12 16:31:00.000	Royals Airport	Sofia International Airport
	10	2016-10-12 19:30:00.000	2016-10-13 12:30:00.000	New York Airport	Sofia International Airport
	7	2016-10-12 23:34:00.000	2016-10-13 03:00:00.000	New York Airport	Moscow Central Airport


	@@@
	*/

/*Task 10: Extract all Customers below 21 years, which have already flew at least once*/
	select cu.customer_id, 
	  concat(cu.first_name, ' ', cu.last_name) as full_name, 
	  2016 - year(date_of_birth) as age
	from customers cu
	where 2016 - year(date_of_birth) < 21
	order by 2016 - year(date_of_birth) desc, cu.customer_id

	# 2016 - year(date_of_birth)
	#(datediff('2016-01-01', date_of_birth)/360)

	/*
	Task 10: Extract all Customers below 21 years, which have already flew at least once
	Extract from the database, all customers which are below 21 years aged, and own a
	 ticket to a flight, which has status – ‘Arrived’, taking their Customer’s ID, 
	 Full Name (First name + Last name separated by a single space), and Age. 
	 Order them by their Age in descending order.  Assume that the current year is 2016. 
	 If two persons have the same age, order them by Customer ID, ascending.
	customer_id	full_name	age
	1	Cassidy Isacc	19

	@@@
	*/

/*Task 11: Extract all Airports and the Count of People departing from them*/
	select  a.airport_id, a.airport_name, count(*) as passengers
	from airports a 
	inner join flights f on a.airport_id = f.origin_airport_id
	inner join tickets t on f.flight_id = t.flight_id
	where f.status = 'Departing'
	group by a.airport_id, a.airport_name
	order by a.airport_id ;

	/*
	Task 11: Extract all Airports and the Count of People departing from them

	Extract from the database, all airports that have any flights with Status-‘Departing’,
	 and extract the count of people that have tickets for those flights.
	  Take the Airports’ IDs, Airports’ Names, and Count of People as ‘passengers’.
	   Order the results by AirportID, ascending. The flights must have some people in them.
	airport_id	airport_name	passengers
	2	New York Airport	1
	4	Moscow Central Airport	1


	@@@
	$$$
	???
	*/


/*Section 4: Programmability*/
/*Task 1: Review Registering Procedure*/
	delimiter $$
	create procedure usp_submit_review(p_customer_id int, 
											 p_review_content varchar(255), 
											 p_review_grade int, 
											 p_airline_name varchar(30))
	begin
		declare v_airline_name varchar(30);
		declare v_airline_id int;
		
		select a.airline_name, a.airline_id
		into v_airline_name, v_airline_id
		from airlines a 
		where a.airline_name = p_airline_name;
		
		if (v_airline_id is null) then 
			signal sqlstate '45000' set Message_Text = 'Airline does not exist.';
		else 
			insert into customer_reviews(review_content, review_grade, airline_id, customer_id)
			values(p_review_content, p_review_grade, v_airline_id, p_customer_id);
		end if;
	end
	$$

	#select * from customer_reviews

	#CALL usp_submit_review (1, 'Content', 10,'Royal Airline');

	#describe customer_reviews


	/*
	Write a procedure – “usp_submit_review”, which registers a review in the customer_reviews table.
	 The procedure should accept the following parameters as input:
	•	customer_id
	•	review_content
	•	review_grade
	•	airline_name
	You can assume that the customer_id , will always be valid, and existent in the database.
	If there is no airline with the given name, raise an error – ‘Airline does not exist.’ with SQL STATE – ‘45000’.
	If no error has been raised, insert the review into the table, with the Airline’s ID. 
	@@@
	*/

/*Task 2: Ticket Purchase Procedure*/
	delimiter $$
	create procedure usp_purchase_ticket(p_customer_id int, 
													 p_flight_id varchar(255), 
													 p_ticket_price decimal(8, 2), 
													 p_class varchar(6),
													 p_seat varchar(5))
	begin
		declare v_customer_bank_acount_balance decimal(10,2);
		
		select balance
		into v_customer_bank_acount_balance
		from customer_bank_accounts
		where customer_id = p_customer_id;
		
		if (p_ticket_price > v_customer_bank_acount_balance) then 
			signal sqlstate '45000' set Message_Text = 'Insufficient bank account balance for ticket purchase.';
		else 
			update customer_bank_accounts
			set balance = balance - p_ticket_price
			where customer_id = p_customer_id;
		
			insert into tickets(price, class, seat, customer_id, flight_id)
			values(p_ticket_price, p_class, p_seat, p_customer_id, p_flight_id);
		end if;
	end
	$$

	#select * from customer_bank_accounts;
	#select * from tickets;
	#describe customer_bank_accounts
	#CALL usp_purchase_ticket (1, 1, 2509.80,'Second', '123-D');

	/*
	Task 2: Ticket Purchase Procedure
	Write a procedure – “usp_purchase_ticket”, which registers a ticket in the tickets table, to a customer 
	that has purchased it, taking from his balance in the customer_bank_accounts table, the provided ticket price. 
	The procedure should accept the following parameters as input:
	•	customer_id
	•	flight_id
	•	ticket_price
	•	class
	•	seat


	You can assume that the customer_id , flight_id, class and seat will always be valid, and existent in the database.
	If the ticket price is greater than the customer’s bank account balance, raise an error ‘Insufficient bank account
	 balance for ticket purchase.’, with SQL STATE – ‘45000’.
	If no error has been raised, insert the ticket into the table Tickets, and reduce the customer’s bank account 
	balance with the ticket price’s value.
	All input parameters will be given in a valid format. Numeric data will be given as numbers, text as text etc.


	@@
	*/


/*Section 5 (BONUS): Update Trigger*/
	/* 
	create table arrived_flights (
		flight_id int primary key auto_increment,
		arrival_time date not null,
		origin varchar(50) not null,
		destination varchar(50) not null,
		passengers int not null 
	); 
	*/
	delimiter $$ 
	create trigger tr_update_arrived_flights
	after update
	on flights
	for each row
	begin
		declare v_origin varchar(50);
		declare v_destination varchar(50);
		declare v_passengers int;

		if (new.status = 'Arrived') then
			select a.airport_name
			into v_origin
			from airports a
			where a.airport_id = new.origin_airport_id;
			
			select a.airport_name
			into v_destination
			from airports a
			where a.airport_id = new.destination_airport_id;
			
			select count(*)
			into v_passengers
			from tickets t
			inner join flights f on t.flight_id = t.flight_id
			where f.flight_id = new.flight_id;
		
			insert into arrived_flights(arrival_time, origin, destination, passengers)
			values(new.arrival_time, v_origin, v_destination, v_passengers);
		end if;
	end
	$$

	/*
	update flights 
	set status = 'Arrived'
	where flights.flight_id = 1
	*/

	#select * from arrived_flights
	#select * from flights
	#describe tickets

	/*
	  You have been tasked to create a table arrived_flights,
	   and a trigger, which comes in action every time a flight’s status, 
		is updated to ‘Arrived’, and only in that case… In all other cases
		 the update should function normally.

	If the trigger is triggered, you need to insert the data about the flight in the table arrived_flights, 
	but you should also update the flight in the Flights table, like it should be done normally.
	Submit only the trigger code.

	*/