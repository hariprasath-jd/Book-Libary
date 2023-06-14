SELECT * FROM sys.tables WHERE OBJECTPROPERTY(object_id,'IsUserTable') = 1

select * from UserLoginInfoes;
select * from UserLocationInfoes;
select * from UserBasicInfoes;
select * from AdminLogins;

select * from Genres;
select * from Authors;
select * from Products;

/* Admin Login table tempoary insert data */
insert into AdminLogins values('hprasath21212@gmail.com','1234','S');


/* Genre table tempoary insert data */
insert into Genres values('Horor','Scary stuff');
insert into Genres values('Romantic','May Your stomach feel butterfly');
insert into Genres values('Action','Get ready for some muscles');
insert into Genres values('Space','A Jounery to outer space');
insert into Genres values('Fantacy','Beyound Imagination');




/* Genre table tempoary insert data */
insert into Products values('It Starts With Us','It Starts with Us is a romance novel by Colleen Hoover, published by Atria Books on October 18, 2022. It is the sequel to her 2016 best-selling novel It Ends with Us. The sequel was first announced in February 2022. It became Simon & Schusters most pre-ordered book of all time. Hoover wrote the novel as a "thank you" to fans of the first novel.','620','/assets/img/b2.jpg',1,2,1);
insert into Products values('The Midnight Library','The Midnight Library is a fantasy novel by Matt Haig, published on 13 August 2020 by Canongate Books. It was abridged and broadcast on BBC Radio 4 over ten episodes in December 2020.','450','/assets/img/b3.jpg',2,5,2);
insert into Products values('It Starts With Us','It Starts with Us is a romance novel by Colleen Hoover, published by Atria Books on October 18, 2022. It is the sequel to her 2016 best-selling novel It Ends with Us. The sequel was first announced in February 2022. It became Simon & Schusters most pre-ordered book of all time. Hoover wrote the novel as a "thank you" to fans of the first novel.','620','/assets/img/b2.jpg',1,2,1);
insert into Products values('It Starts With Us','It Starts with Us is a romance novel by Colleen Hoover, published by Atria Books on October 18, 2022. It is the sequel to her 2016 best-selling novel It Ends with Us. The sequel was first announced in February 2022. It became Simon & Schusters most pre-ordered book of all time. Hoover wrote the novel as a "thank you" to fans of the first novel.','620','/assets/img/b2.jpg',1,2,1);
insert into Products values('It Starts With Us','It Starts with Us is a romance novel by Colleen Hoover, published by Atria Books on October 18, 2022. It is the sequel to her 2016 best-selling novel It Ends with Us. The sequel was first announced in February 2022. It became Simon & Schusters most pre-ordered book of all time. Hoover wrote the novel as a "thank you" to fans of the first novel.','620','/assets/img/b2.jpg',1,2,1);
insert into Products values('It Starts With Us','It Starts with Us is a romance novel by Colleen Hoover, published by Atria Books on October 18, 2022. It is the sequel to her 2016 best-selling novel It Ends with Us. The sequel was first announced in February 2022. It became Simon & Schusters most pre-ordered book of all time. Hoover wrote the novel as a "thank you" to fans of the first novel.','620','/assets/img/b2.jpg',1,2,1);
insert into Products values('It Starts With Us','It Starts with Us is a romance novel by Colleen Hoover, published by Atria Books on October 18, 2022. It is the sequel to her 2016 best-selling novel It Ends with Us. The sequel was first announced in February 2022. It became Simon & Schusters most pre-ordered book of all time. Hoover wrote the novel as a "thank you" to fans of the first novel.','620','/assets/img/b2.jpg',1,2,1);
insert into Products values('It Starts With Us','It Starts with Us is a romance novel by Colleen Hoover, published by Atria Books on October 18, 2022. It is the sequel to her 2016 best-selling novel It Ends with Us. The sequel was first announced in February 2022. It became Simon & Schusters most pre-ordered book of all time. Hoover wrote the novel as a "thank you" to fans of the first novel.','620','/assets/img/b2.jpg',1,2,1);
insert into Products values('It Starts With Us','It Starts with Us is a romance novel by Colleen Hoover, published by Atria Books on October 18, 2022. It is the sequel to her 2016 best-selling novel It Ends with Us. The sequel was first announced in February 2022. It became Simon & Schusters most pre-ordered book of all time. Hoover wrote the novel as a "thank you" to fans of the first novel.','620','/assets/img/b2.jpg',1,2,1);



/* Genre table tempoary insert data */
insert into Authors values('Colleen Hoover','olleen Hoover is an American author who primarily writes novels in the romance and young adult fiction genres. She is best known for her 2016 romance novel, It Ends with Us. Many of her works were self-published, before being picked up by a publishing house.','https://github.com/mdo.png');
insert into Authors values('Matt Haig','Matt Haig is an English author and journalist. He has written both fiction and non-fiction books for children and adults, often in the speculative fiction genre.','/assets/img/haig-matt.jpg');



/* Supplier table tempoary insert data */
insert into Suppliers values('Colleen Hoover','7855487541','collenhover@gmail.com','self shiping and other details');
insert into Suppliers values('Haig Matt','986548754','haigmatt@gmail.com','self shiping and other details');


exec sp_help Products;