create table deposit_types(
	deposit_type_id int primary key,
	name varchar(20)
);

create table deposits (
	deposit_id int primary key auto_increment,
	amount decimal(10, 2),
	start_date date,
	end_date date,
	deposit_type_id int,
	customer_id int,
	constraint fk_deposits_deposit_types foreign key(deposit_type_id)
	references deposit_types(deposit_type_id),
	constraint fk_deposits_customers foreign key(customer_id)
	references customers(customer_id)
);

create table employees_deposits(
	employee_id int,
	deposit_id int,
	constraint pk_employees_deposits primary key (employee_id, deposit_id),
	constraint fk_employees_deposists_employees foreign key (employee_id) references employees (employee_id),
	constraint fk_employees_deposists_deposits foreign key (deposit_id) references deposits (deposit_id)
);

create table credit_history(
	credit_history_id int primary key,
	mark char(1),
	start_date date,
	end_date date,
	customer_id int,
	constraint fk_credit_history_customers foreign key (customer_id) references customers (customer_id)
);

create table payments(
	payment_id int primary key,
	date date,
	amount decimal(10, 2),
	loan_id int,
	constraint fk_payments_loans foreign key (loan_id) references loans (loan_id)
);

create table users(
	user_id int primary key,
	user_name varchar(20),
	password varchar(20),
	customer_id int unique,
	constraint fk_users_customers foreign key (customer_id) references customers (customer_id)
);

alter table employees
add manager_id int,
add constraint fk_employees_employees foreign key(manager_id) references employees(employee_id);
/*

users
Column Name	Data Type	Constraints
user_id	Integer from –2,147,483,648 to 2,147,483,647	Unique table identificator
user_name	String up to 20 symbols	
password	String up to 20 symbols	
customer_id	Integer from –2,147,483,648 to 2,147,483,647	Relationship with table Customers, Unique Values

*/

/******************************************************************************************************/
insert into deposit_types (deposit_type_id,	name)
values
(1,	'Time Deposit'),
(2,	'Call Deposit'),
(3,	'Free Deposit');

insert into deposits (amount, start_date, end_date, deposit_type_id, customer_id)
select 
   case when c.date_of_birth > '19800101' then 1000
	else 1500
	end 
	+
	case when c.gender = 'm' then 100 else 200 end as amount,
	now() as start_date, 
	null as end_date, 
	case when c.customer_id > 15 then 3
	     else 
		      case when c.customer_id % 2 = 0 then 2
		  		   else 1
			  end 
	end as deposit_type_id,
	c.customer_id as customer_id
from customers c where c.customer_id < 20;

insert into employees_deposits (employee_id, deposit_id)
values (15, 4),
	   (20, 15),
	   (8, 7),
	   (4, 8),
	   (3, 13),
	   (3, 8),
	   (4, 10),
	   (10, 1),
	   (13, 4),
	   (14, 9);
/******************************************************************************************************/
update employees
set manager_id = (case 
					when employee_id between 2 and 10 then 1 
					when employee_id between 12 and  20 then 11 
					when employee_id between 22 and 30 then 21 
					when employee_id in(11,21) then 1
				  end);

/*
2.	Update Employees
Update table Employees. The manager id should have the following values:
•	If EmployeeID is in the range [2;10] then the value is 1
•	If EmployeeID is in the range [12;20] then the value is 11
•	If EmployeeID is in the range [22;30] then the value is 21
•	If EmployeeID is in 11 or 21 then 1

*/
/******************************************************************************************************/
delete from employees_deposits 
where deposit_id = 9 or employee_id = 3;
/*
3.	Delete Records
Delete all records from EmployeeDeposits if the DepositID is 9 or the EmployeeID is 3;
*/

#select * from employees_deposits
/******************************************************************************************************/
select employee_id, hire_date, salary, branch_id
from employees 
where salary > 2000
and hire_date > '2009-06-15';

/*
1.	Employees’ Salary
Write a query that returns 
•	employee_id
•	hire_date
•	salary
•	branch_id
From table Employees. Filter employees which salaries are higher than 2000 and their hire date is after 15/06/2009.
Example

employee_id	hire_date	salary	branch_id
5	2009-12-23	2295.88	12
*/
/******************************************************************************************************/
select first_name, date_of_birth, floor(datediff('2016-10-01', date_of_birth)/360) as age
from customers 
where datediff('2016-10-01', date_of_birth)/360 between 40 and 50 

/*
2.	Customer Age
Write a query that returns 
•	first_name
•	date_of_birth
•	age
of all customers who are between 40 and 50 years old. The range is inclusive. Consider that today is 01-10-2016. Assume that each year has 360 days.
Example

first_name	date_of_birth	age
Bruce	1970-09-17	46
*/
/******************************************************************************************************/
select customer_id, first_name, last_name, gender, city_name
from customers 
join cities 
on customers.city_id = cities.city_id
where (last_name like 'Bu%'
or first_name like '%a')
and length(city_name) > 7
order by customer_id;

/*
3.	Customer City
Write a query that returns 
•	customer_id
•	first_name
•	last_name
•	gender
•	city_name
for all customers whose last name starts with ‘Bu’ or first name ends with ‘a’. 
Moreover, for those customers the length of the city name should at least 8 letters.
 Sort by CustomerID in ascending order.
Example

customer_id	first_name	Last_name	gender	city_name
25	Debra	Crawford	F	Povorino
*/
/******************************************************************************************************/
select e.employee_id, e.first_name, a.account_number
from employees e
inner join employees_accounts ea on e.employee_id = ea.employee_id
inner join accounts a on a.account_id = ea.account_id
where year(a.start_date) > 2012
order by e.first_name desc
limit 5;

/*
4.	Employee Accounts
Write a query that returns top 5
•	employee_id
•	first_name
•	account_number
of all employees who are responsible for maintaining accounts which has started after the year of 2012. 
Sort the results by the first name of the employees in descending order.
Example

employee_id	first_name	account_number
26	William	501012430845
*/
/******************************************************************************************************/
select c.city_name, b.name as name, count(*) as employees_count
from employees e
inner join branches b on e.branch_id = b.branch_id
inner join cities c on b.city_id = c.city_id
where c.city_id not in (4, 5) 
group by c.city_name, b.name
having count(*) >= 3;

/* 5.	Employee Cities
Write a query that returns 
•	city_name
•	name (of the branch)
•	employees_count
The count of all employees grouped by city name and branch name.
 Exclude cities with id 4 and 5. Don’t show groups with less than 3 employees. 
Example

city_name	name	employees_count
Budapest	Angela	3
*/
/******************************************************************************************************/
select sum(l.amount) as total_loan_amount, max(l.interest) as max_interest, min(e.salary) as min_employee_count
from employees e 
inner join employees_loans el on e.employee_id = el.employee_id
inner join loans l on l.loan_id = el.loan_id;

/*
6.	Loan Statistics
Write a query that returns 
•	The total amount of loans
•	Max interest of loans
•	Min salary of employees
Of all employees that are responsible for maintaining the loans.
Example

total_loan_amount	max_interest	min_employee_salary
1469561.30	0.91	1639.97
*/
/******************************************************************************************************/
create view employees_cities_3 as 
select e.first_name, c.city_name
from employees e
inner join branches b on e.branch_id = b.branch_id
inner join cities c on c.city_id = b.city_id
limit 3;

create view customers_cities_three as 
select cu.first_name, c.city_name
from customers cu
inner join cities c on cu.city_id = c.city_id
limit 3;

select * from employees_cities_3
union
select * from customers_cities_three;

/*
7.	Unite People
Write a query that returns top 3 employees’ first names and the city name
 of their branch followed by top 3 customer’s first names and the name of the city they live in.
Example

first_name	city_name
Sarah	Uppsala

*/
/******************************************************************************************************/
select c.customer_id, c.height
from customers c
left join accounts a on c.customer_id = a.customer_id
where a.account_id is null 
and c.height between 1.74 and 2.04;

/*
8.	Customers without Accounts
Write a query that returns 
•	customer_id
•	height
of all customers who doesn’t have accounts. Filter only those who are tall between 1.74 and 2.04.
Example

customer_id	height
11	1.78
*/
/******************************************************************************************************/
select cu.customer_id, l.amount
from customers cu
inner join loans l on cu.customer_id = l.customer_id
where l.amount > 
             (select avg(l1.amount) 
				  from loans l1 
				  inner join customers cu1 on l1.customer_id = cu1.customer_id 
				  where cu1.gender = 'm')
order by cu.last_name 
limit 5;
/*
9.	Customers without Accounts
Write a query that returns top 5 rows
•	customer_id
•	amount
of all customers who have loans higher than the average loan amount of the male customers. 
Sort the data by customer last name in ascending order.
Example

customer_id	amount
4	88067.24

*/
/******************************************************************************************************/
select cu.customer_id, cu.first_name, a.start_date
from customers cu
inner join accounts a on cu.customer_id = a.customer_id
order by a.start_date
limit 1;

/*
10.	Oldest Account
Write a query that returns 
•	customer_id
•	first_name
•	start_date
for the customer with the oldest account.
Example

customer_id	first_name	start_date
27	Howard	2010-10-13

*/
/******************************************************************************************************/
#delimiter $$
create function udf_concat_string(string_1 varchar(255), string_2 varchar(255))
returns varchar(255)
begin
	declare string_1_reversed varchar(255);
	declare string_2_reversed varchar(255);
	
	set string_1_reversed := reverse(string_1);
	set string_2_reversed := reverse(string_2);
	
	return concat (string_1_reversed, string_2_reversed);
end
#$$

#select udf_concat_string('soft', 'uni');

/*
1.	String Joiner Function

Write a function with name udf_concat_string that reverses two strings,
 joins them and returns the concatenation.
  The function should have two input parameters of type VARCHAR.

*/
/******************************************************************************************************/
delimiter $$
create procedure usp_customers_with_unexpired_loans(p_customer_id int)
begin
	select cu.customer_id, cu.first_name, l.loan_id, l.expiration_date 
	from customers cu
	inner join loans l on cu.customer_id = l.customer_id
	where l.expiration_date is null
 	and cu.customer_id = p_customer_id;
end
$$

#CALL usp_customers_with_unexpired_loans(9);

/*
2.	Unexpired Loans Procedure

Write a procedure that returns a customer if it has unexpired loan. The following result set should be returned:
•	customer_id
•	first_name
•	loan_id
The function should have one parameter for customer_id of type integer. 
Name the function usp_customers_with_unexpired_loans. 
If the id of the customer doesn’t have unexpired loans return an empty result set.
Example

CALL usp_customers_with_unexpired_loans(9)

CustimerID	FirstName	LoanID
9	Bobby	23
*/
/******************************************************************************************************/
delimiter $$
create procedure usp_take_loan(p_customer_id int, 
										 p_loan_amount decimal(18,2), 
										 p_interest decimal(4,2), 
										 p_start_date date)
begin
	start transaction;
	insert into loans(start_date, amount, interest, customer_id)
	values(p_start_date, p_loan_amount, p_interest, p_customer_id);
	
	if (p_loan_amount not between 0.01 and 100000) then 
		signal sqlstate '45000' set Message_Text = 'Invalid Loan Amount.';
		rollback;
	else commit;
	end if;
end
$$

#CALL usp_take_loan (1, 500, 1,'20160915');

/*
3.	Take Loan Procedure
Write a procedure that adds a loan to an existing customer. The procedure should have the following input parameters:
•	customer_id
•	loan_amount
•	interest
•	start_date
If the loan amount is not between 0.01 AND 100000 raise an error ‘Invalid Loan Amount.’ And rollback the transaction.
If no error is raised insert the loan into table Loans. 
The column loan_id has an auto_increment property so there is no need to specify a value for it. 
Name the procedure usp_take_loan.
Example

CALL usp_take_loan (1, 500, 1,'20160915')

One row added.
*/
/******************************************************************************************************/
delimiter $$ 
create trigger tr_hire_employee
after insert 
on employees
for each row
begin
	 update employees_loans el
	 set el.employee_id = new.employee_id # id = 31
	 where el.employee_id + 1 = new.employee_id; # 30 + 1;
end
$$

/*
4.	Trigger Hire Employee
Write a trigger on table Employees. After an insert of a new employee the new employee
 takes the loan maintenance of the previous employee.
Hint
Your trigger should update table employees_loans

Example
Before Insert

employee_id	first_name	hire_date	salary	branch_id
30	Diane	2006-03-18	2574.01	6

employee_id	loan_id
30	7

INSERT INTO employees values (31,' Jake ','20161212',500,2)

After Insert

employee_id	first_name	hire_date	salary	branch_id
30	Diane	2006-03-18	2574.01	6
31	Jake	2016-12-12	500	2

employee_id	loan_id
31	7
*/
/******************************************************************************************************/
#create table account_logs as 
#select * from accounts 
#where null = null;

#delimiter $$ 
create trigger tr_delete_account
before delete
on accounts
for each row
begin
	delete from employees_accounts
	where account_id = old.account_id;
	
	insert into account_logs(account_id, account_number, start_date, customer_id)
	values(old.account_id, old.account_number, old.start_date, old.customer_id);
end
#$$

/*
1.	Delete Trigger

Create a table with the same structure as table accounts and name it account_logs.
 Then create a trigger that logs the deleted records from table accounts into table account_logs. 
 Post in judge only the create trigger statement.

Example

DELETE FROM accounts
WHERE customer_id = 4

 account_logs
account_id	account_number	start_date	customer_id
31	352806149112	2016-08-05	4

*/
/******************************************************************************************************/
/*
	TURN ON MYSQL SERVICE:
	
	"Search for 'Services' in the Windows Search Bar.
	Click on 'Services', which should be the only hit.
	Scroll down to 'MySQL56'.
	Right-click on this item and hit 'Start' or 'Restart'."
*/