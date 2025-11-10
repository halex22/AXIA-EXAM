create database blogDB;

\c blogDB;

create table if not exists post (
    id serial primary key,
    title varchar(255) not null unique,
    body text not null,
    created_at timestamp default current_timestamp
);

create table if not exists comment(
    id serial primary key,
    post_id int references post(id) on delete cascade,
    author varchar(255) not null,
    content varchar(510),
    created_at timestamp default current_timestamp
);


create index idx_comment_post_id on comment(post_id);



INSERT INTO post (title, body)
VALUES
('Exploring PostgreSQL Indexes', 'In this post, we discuss how indexes improve query performance and when to use them.'),
('Understanding Foreign Keys in SQL', 'This article explains how foreign keys maintain referential integrity between tables.');

INSERT INTO comment (post_id, author, content)
VALUES
(1, 'Alice', 'Great explanation on indexes! Helped speed up my queries.'),
(1, 'Bob', 'Would love to see a follow-up on index types like GIN and GiST.'),
(1, 'Charlie', 'Could you add examples with EXPLAIN ANALYZE next time?'),
(2, 'Diana', 'Finally understood foreign keys! Thanks for the clear examples.'),
(2, 'Ethan', 'What happens if I delete a parent record? Will the child rows be removed automatically?');
