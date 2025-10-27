
CREATE DATABASE todoDB;

\c todoDB;

CREATE TABLE category (
  id SERIAL PRIMARY KEY,
  category_name VARCHAR(255) NOT NULL
);

CREATE TABLE todo (
  id SERIAL PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  completed BOOLEAN DEFAULT FALSE,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  category_id INT REFERENCES category(id)
  CONSTRAINT unique_title_per_category UNIQUE (title, category_id)
);


INSERT INTO category (category_name) VALUES
('Work'),
('Personal'),
('Shopping'),
('Health'),
('Finance'),
('Study'),
('Home'),
('Errands'),
('Travel'),
('Miscellaneous');


INSERT INTO todo (title, category_id)
VALUES
('Finish project report', 1),     -- Work
('Go to the gym', 4),             -- Health
('Buy groceries', 3),             -- Shopping
('Book flight tickets', 9),       -- Travel
('Pay electricity bill', 5);      -- Finance