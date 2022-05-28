create database multi_chat;

use multi_chat;

create table client (

clientName varchar(50) not null,
clientPassword varchar(50) not null,
clientIP varchar(50) not null primary key
);

INSERT INTO client 
(clientName, clientPassword, clientIP)
VALUES 
('client1', '123', '127.0.0.1'),
('client2', '456', '127.0.0.2'),
('client3', '789', '127.0.0.3');

select * from client;

drop table client

create table message(
id int identity(1,1) primary key,
message varchar(255),
clientIP varchar(50),
FOREIGN KEY (clientIP) REFERENCES client(clientIP)
)

select * from message;
drop table message

create table groupChat(
id int identity(1,1) primary key,
groupName varchar(50),
clientIP varchar(50),
FOREIGN KEY (clientIP) REFERENCES client(clientIP))

select * from groupChat;


drop table groupChat


drop database multi_chat