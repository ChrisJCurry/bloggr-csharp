-- CREATE TABLE profiles
-- (
--     id VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     nickName VARCHAR(255) NOT NULL,
--     picture VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id)
-- );

-- CREATE TABLE blogs
-- (
--     id INTEGER NOT NULL auto_increment,
--     title VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     imgUrl VARCHAR(255) NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),

--     FOREIGN KEY (creatorId)
--         REFERENCES profiles (id)
--         ON DELETE CASCADE
-- );

-- USE bloggrcurry;

-- CREATE TABLE comments
-- (
--     id INTEGER NOT NULL auto_increment,
--     body VARCHAR(255) NOT NULL,
--     blogId int NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),

--     FOREIGN KEY (creatorId)
--         REFERENCES profiles (id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (blogId)
--         REFERENCES blogs (id)
--         ON DELETE CASCADE
-- );