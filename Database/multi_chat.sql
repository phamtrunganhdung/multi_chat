create database multi_chat;

use multi_chat;

create table client (
id int identity(1,1) primary key,
clientName varchar(50) not null,
clientPassword varchar(50) not null
);

INSERT INTO client 
(clientName, clientPassword)
VALUES 
('client1', '123'),
('client2', '456'),
('client3', '789');

select * from client;