SELECT * FROM sys.tables WHERE OBJECTPROPERTY(object_id,'IsUserTable') = 1

select * from UserLoginInfoes;
select * from UserLocationInfoes;
select * from UserBasicInfoes;


select * from AdminLogins;
select * from AdminDetails; 


select * from Genres;
select * from Authors;
select * from Products;
select * from Suppliers;

/* Admin Login table tempoary insert data */
insert into AdminLogins values('hprasath21212@gmail.com','1234','S');
update AdminLogins set AdminId='arun@gmail.com',AdminPassword='1234',AdminAttributte='A' where id = 3;


insert into AdminDetails values(1,'Hari Prasath','hprasath21212@gmail.com','744895571','Theni');



/* Genre table tempoary insert data */
insert into Genres values('Horor','Scary stuff');
insert into Genres values('Romantic','May Your stomach feel butterfly');
insert into Genres values('Action','Get ready for some muscles');
insert into Genres values('Space','A Jounery to outer space');
insert into Genres values('Fantacy','Beyound Imagination');
insert into Genres values('Family Drama','Family drama portrays the emotional complexities and conflicts that arise within a family, impacting relationships and often requiring resolution through open communication and understanding.');
insert into Genres values('Non-Fiction ','Non-fiction is any document or media content that attempts, in good faith, to convey information only about the real world, rather than being grounded in imagination. Non-fiction typically aims to present topics objectively based on historical, scientific, and empirical information.');




/* Genre table tempoary insert data */
insert into Products values('It Starts With Us','It Starts with Us is a romance novel by Colleen Hoover, published by Atria Books on October 18, 2022. It is the sequel to her 2016 best-selling novel It Ends with Us. The sequel was first announced in February 2022. It became Simon & Schusters most pre-ordered book of all time. Hoover wrote the novel as a "thank you" to fans of the first novel.','620','/assets/img/b2.jpg',1,2,1);
insert into Products values('The Midnight Library','The Midnight Library is a fantasy novel by Matt Haig, published on 13 August 2020 by Canongate Books. It was abridged and broadcast on BBC Radio 4 over ten episodes in December 2020.','450','/assets/img/b3.jpg',2,5,2);
insert into Products values('The God of Small Things ','The God of Small Things is a family drama novel written by Indian writer Arundhati Roy. Roys debut novel, it is a story about the childhood experiences of fraternal twins whose lives are destroyed by the "Love Laws" prevalent in 1960s Kerala, India.','300','/assets/img/w11.jpg',3,6,3);
insert into Products values('Essential Tales and Poems (Barnes & Noble Signature Editions)','Poe had a knack for infusing everything he wrote with visceral dread. His characters and narrators tend towards the mentally fragile and the insane, people who are haunted by things that might be literal or might be manifestations of their unsound thought processes.','220','/Uploaded_Cover_Image/book1.jpg',1003,1,1003);

update Products set ProductCoverImage = '/assets/img/b2.jpg' where id = 1;
update Products set ProductCoverImage = 'C:\\Users\\hpras\\OneDrive\\Lab Pc\\DotNET\\Applications\\Book Libary\\Uploaded_Cover_Image\\book1.jpg' where id = 1003;


/* Auhtor table tempoary insert data */
insert into Authors values('Colleen Hoover','olleen Hoover is an American author who primarily writes novels in the romance and young adult fiction genres. She is best known for her 2016 romance novel, It Ends with Us. Many of her works were self-published, before being picked up by a publishing house.','https://github.com/mdo.png');
insert into Authors values('Matt Haig','Matt Haig is an English author and journalist. He has written both fiction and non-fiction books for children and adults, often in the speculative fiction genre.','/assets/img/haig-matt.jpg');
insert into Authors values('Arundhati Roy','Suzanna Arundhati Roy is an Indian author best known for her novel The God of Small Things, which won the Booker Prize for Fiction in 1997 and became the best-selling book by a non-expatriate Indian author. She is also a political activist involved in human rights and environmental causes','/assets/img/arundhati_roy.jpg');
insert into Authors values('Edgar Allan Poe','Edgar Allan Poe was an American writer, poet, editor, and literary critic who is best known for his poetry and short stories, particularly his tales of mystery and the macabre. He is widely regarded as a central figure of Romanticism in the United States, and of American literature.','/assets/img/Edgar Allan Poe.jpg');
insert into Authors values('J. K. Rowling','Joanne Rowling, best known by her pen name J. K. Rowling, is a British author and philanthropist. She wrote Harry Potter, a seven-volume childrens fantasy series published from 1997 to 2007. The series has sold over 600 million copies, been translated into 84 languages, and spawned a global media franchise including films and video games.','/Uploaded_Cover_Image/Author/a7.jpg');
insert into Authors values('George Orwell','Eric Arthur Blair, better known by his pen name George Orwell, was an English novelist, essayist, journalist, and critic. His work is characterised by lucid prose, social criticism, opposition to totalitarianism, and support of democratic socialism. Orwell produced literary criticism, poetry, fiction and polemical journalism.','/Uploaded_Cover_Image/Author/a8.jpg');
insert into Authors values('R. K. Narayan','Rasipuram Krishnaswami Iyer Narayanaswami was an Indian writer and novelist known for his work set in the fictional South Indian town of Malgudi. He was a leading author of early Indian literature in English along with Mulk Raj Anand and Raja Rao.','/Uploaded_Cover_Image/Author/a13.jpg');

update Authors set AuthorImage='/Uploaded_Cover_Image/Author/a7.jpg' where Id=1004;

delete from Authors where Id=1007 or Id=1008 or Id=1009 or Id=1010 or Id=1011 or Id=1012 ;

/* Supplier table tempoary insert data */
insert into Suppliers values('Colleen Hoover','7855487541','collenhover@gmail.com','self shiping and other details');
insert into Suppliers values('Haig Matt','986548754','haigmatt@gmail.com','self shiping and other details');
insert into Suppliers values('Penguin Books (India)','986548754','penguinbooks@gmail.com','Publishng House');
insert into Suppliers values('Jeffrey Goddin','9846578546','jeffreygoddin@gmail.com','self shiping and other details');

update Suppliers set SupplierName='Colleen Hoover',SupplierPhone = '7855487541',SupplierEmail='collenhover@gmail.com',SupplierDescription='self shiping and other details' where Id=1;

exec sp_help AdminDetails;