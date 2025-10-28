create database blog_db;

\c blog_db;

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
