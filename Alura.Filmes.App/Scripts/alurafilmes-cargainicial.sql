-- Apagando os dados
DELETE FROM customer ;
DELETE FROM film_category ;
DELETE FROM film_actor ;
DELETE FROM film ;
DELETE FROM category ;
DELETE FROM staff ;
DELETE FROM actor ;
DELETE FROM language ;

--
-- Carga Inicial
--

-- table language
SET IDENTITY_INSERT [dbo].[language] ON
INSERT INTO [dbo].[language] ([language_id], [name], [last_update]) VALUES (1, N'English             ', N'2006-02-15 05:02:19')
SET IDENTITY_INSERT [dbo].[language] OFF

-- table actor
SET IDENTITY_INSERT [dbo].[actor] ON
INSERT INTO [dbo].[actor] ([actor_id], [first_name], [last_name], [last_update]) VALUES (201, N'MEL', N'GIBSON', N'2017-08-29 16:36:23')
SET IDENTITY_INSERT [dbo].[actor] OFF

-- table staff
SET IDENTITY_INSERT [dbo].[staff] ON
INSERT INTO [dbo].[staff] ([staff_id], [first_name], [last_name], [email], [active], [username], [password], [last_update]) VALUES (1, N'Mike', N'Hillyer', N'Mike.Hillyer@sakilastaff.com', 1, N'Mike', N'8cb2237d0679ca88db6464eac60da96345513964', N'2006-02-15 04:57:16')
INSERT INTO [dbo].[staff] ([staff_id], [first_name], [last_name], [email], [active], [username], [password], [last_update]) VALUES (2, N'Jon', N'Stephens', N'Jon.Stephens@sakilastaff.com', 1, N'Jon', N'8cb2237d0679ca88db6464eac60da96345513964', N'2006-02-15 04:57:16')
SET IDENTITY_INSERT [dbo].[staff] OFF

-- table category
SET IDENTITY_INSERT [dbo].[category] ON
INSERT INTO [dbo].[category] ([category_id], [name], [last_update]) VALUES (16, N'Travel', N'2006-02-15 04:46:27')
SET IDENTITY_INSERT [dbo].[category] OFF


-- table film
SET IDENTITY_INSERT [dbo].[film] ON
INSERT INTO [dbo].[film] ([film_id], [title], [description], [release_year], [language_id], [original_language_id], [length], [rating], [last_update]) VALUES (1000, N'ZORRO ARK', N'A Intrepid Panorama of a Mad Scientist And a Boy who must Redeem a Boy in A Monastery', N'2006', 1, NULL, 50, N'NC-17', N'2006-02-15 05:03:42')
SET IDENTITY_INSERT [dbo].[film] OFF


-- table film_actor

INSERT INTO [dbo].[film_category] ([film_id], [category_id], [last_update]) VALUES (1000, 5, N'2006-02-15 05:07:09')


-- table customer
SET IDENTITY_INSERT [dbo].[customer] ON
INSERT INTO [dbo].[customer] ([customer_id], [first_name], [last_name], [email], [active], [create_date], [last_update]) VALUES (100, N'ROBIN', N'HAYES', N'ROBIN.HAYES@sakilacustomer.org', 1, N'2006-02-14 22:04:36', N'2006-02-15 04:57:20')
SET IDENTITY_INSERT [dbo].[customer] OFF


