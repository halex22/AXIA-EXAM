create DATABASE contactsDB;

\c contactsDB;

create table if not exists groups (
    id serial primary key,
    name varchar(255) unique 
);

create table if not exists contacts (
    id serial primary key,
    first_name varchar(255) not null,
    last_name varchar(255),
    created_at timestamp default CURRENT_TIMESTAMP,
    constraint unique_fullname unique (first_name, last_name)
);

create table if not exists group_contact (
    id serial primary key,
    group_id int references groups(id),
    contact_id int references contacts(id)
    constraint unique_group_contact unique (group_id, contact_id)
);