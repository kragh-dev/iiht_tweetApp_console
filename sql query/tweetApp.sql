USE [tweetAppDB]
GO

CREATE TABLE app_user (
	user_id int IDENTITY(1,1) PRIMARY KEY,
	first_name nvarchar(100) NOT NULL,
	last_name nvarchar(100),
	gender nvarchar(10) NOT NULL,
	dob date,
	email nvarchar(100) NOT NULL UNIQUE,
	password nvarchar(20) NOT NULL
)

CREATE TABLE tweet (
	tweet_id int IDENTITY(1,1),
	user_id int FOREIGN KEY REFERENCES app_user(user_id),
	text nvarchar(200) NOT NULL,
	created_at datetime NOT NULL
)

INSERT INTO app_user
           ([first_name]
           ,[last_name]
           ,[gender]
           ,[dob]
           ,[email]
           ,[password])
     VALUES
           ('Kaarthikeyan'
           ,'Raghavan'
           ,'Male'
           ,'1998-06-23'
           ,'kaarthik.raghavan@gmail.com'
           ,'kaarthik23')
GO

SELECT * from app_user

ALTER TABLE app_user
ALTER COLUMN dob date;

update app_user set dob = '1998-06-23' where id = 1

ALTER TABLE app_user
ADD PRIMARY KEY (id);




