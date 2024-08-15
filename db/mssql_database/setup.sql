CREATE TABLE Genre (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255) NOT NULL
);

-- Create Movie table
CREATE TABLE Movie (
    id           BIGINT PRIMARY KEY IDENTITY(1,1),
    title        VARCHAR(255) NOT NULL,
    genre        BIGINT       NOT NULL,
    description  varchar(max) NULL,
    duration     INT          NOT NULL,
    release_date DATETIME     NOT NULL,
    FOREIGN KEY (genre) REFERENCES Genre(id)
);

-- Create Theater table
CREATE TABLE Theater (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255) NOT NULL,
    location varchar(max) NOT NULL
);

-- Create MovieProjection table
CREATE TABLE MovieProjection (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    movie_id BIGINT NOT NULL,
    theater_id BIGINT NOT NULL,
    start_datetime DATETIME NOT NULL,
    FOREIGN KEY (movie_id) REFERENCES Movie(id),
    FOREIGN KEY (theater_id) REFERENCES Theater(id)
);