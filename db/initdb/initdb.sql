CREATE TYPE language AS ENUM (
    'en_us',
    'en_gb',
    'de_de'
);

CREATE DOMAIN mandatory_language
    AS language
    NOT NULL;

CREATE DOMAIN mandatory_character_varying_255
    AS character varying(255)
    NOT NULL;

CREATE TYPE place_name AS (
    language mandatory_language,
    name mandatory_character_varying_255
);


CREATE TABLE place (
    id uuid,
    names place_name[] NOT NULL,
    tel_code character varying(10)
);

