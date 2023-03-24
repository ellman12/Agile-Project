-- Run this file to initialize database for first time use.
CREATE EXTENSION IF NOT EXISTS "uuid-ossp"; -- Needed for uuid_generate_v1

DROP DATABASE IF EXISTS "AgileProject";
CREATE DATABASE "AgileProject" WITH OWNER = postgres ENCODING = 'UTF8' LC_COLLATE = 'English_United States.1252' LC_CTYPE = 'English_United States.1252' TABLESPACE = pg_default CONNECTION LIMIT = -1 IS_TEMPLATE = False;

DROP TABLE IF EXISTS users CASCADE;
CREATE TABLE public.users (
    user_id uuid UNIQUE NOT NULL DEFAULT uuid_generate_v1(),
    username text UNIQUE NOT NULL,
    first_name text NOT NULL,
    last_name text NOT NULL,
    email text NOT NULL,
    password text NOT NULL,
    PRIMARY KEY (user_id, username)
);
ALTER TABLE IF EXISTS public.users OWNER to postgres;

DROP TABLE IF EXISTS folders CASCADE;
CREATE TABLE folders ( -- Groups sets of cards together.
    creator uuid NOT NULL REFERENCES users(user_id) ON DELETE CASCADE,
    folder_id uuid UNIQUE PRIMARY KEY NOT NULL DEFAULT uuid_generate_v1(),
    name text NOT NULL,
    public bool NOT NULL DEFAULT FALSE
);
ALTER TABLE IF EXISTS public.folders OWNER to postgres;

DROP TABLE IF EXISTS sets CASCADE;
CREATE TABLE sets ( -- Groups cards together.
    creator uuid REFERENCES users(user_id) NOT NULL,
    set_id uuid UNIQUE PRIMARY KEY NOT NULL DEFAULT uuid_generate_v1(),
    name text NOT NULL,
    folder_id uuid REFERENCES folders(folder_id),
    created timestamp without time zone NOT NULL default now()
);
ALTER TABLE IF EXISTS public.sets OWNER to postgres;

DROP TABLE IF EXISTS flashcards;
CREATE TABLE flashcards (
    set_id uuid REFERENCES sets(set_id) NOT NULL,
    card_id uuid UNIQUE PRIMARY KEY NOT NULL DEFAULT uuid_generate_v1(),
    question text NOT NULL,
    answer text NOT NULL
);
ALTER TABLE IF EXISTS public.flashcards OWNER to postgres;