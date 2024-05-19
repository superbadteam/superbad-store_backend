drop table "__EFMigrationsHistory" cascade;

drop table "ProductImages" cascade;

drop table "ProductTypes" cascade;

drop table "Products" cascade;

drop table "Categories" cascade;

--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1 (Debian 16.1-1.pgdg120+1)
-- Dumped by pg_dump version 16.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Categories" (
    "Id" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text,
    "ParentId" uuid
);


ALTER TABLE public."Categories" OWNER TO postgres;

--
-- Name: ProductImages; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ProductImages" (
    "Id" uuid NOT NULL,
    "Url" text NOT NULL,
    "ProductId" uuid NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
);


ALTER TABLE public."ProductImages" OWNER TO postgres;

--
-- Name: ProductTypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ProductTypes" (
    "Id" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "Quantity" integer NOT NULL,
    "Price" double precision NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text,
    "ImageUrl" text
);


ALTER TABLE public."ProductTypes" OWNER TO postgres;

--
-- Name: Products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Products" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "Description" text NOT NULL,
    "CategoryId" uuid NOT NULL,
    "Sold" integer NOT NULL,
    "Condition" integer NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
);


ALTER TABLE public."Products" OWNER TO postgres;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Data for Name: Categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('1c6ade43-ece6-43e2-a0fe-2181aac4b211', 'Automotive', NULL, NULL, '2024-05-18 17:47:47.510556+00', 'guest', '2024-05-18 17:47:47.596076+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('1d2f34aa-543d-4708-b72b-8624914c3a84', 'Pet Supplies', NULL, NULL, '2024-05-18 17:47:47.510556+00', 'guest', '2024-05-18 17:47:47.596076+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('4015dd5c-56f8-484f-a2fb-1ddfeab73035', 'Beauty & Personal Care', NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', '2024-05-18 17:47:47.596075+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('56d02381-f72c-46c8-987a-7a94d4713788', 'Electronics', NULL, NULL, '2024-05-18 17:47:47.509985+00', 'guest', '2024-05-18 17:47:47.595872+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('847724f7-03bd-425a-b38a-341e401eb4cb', 'Sports & Outdoors', NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', '2024-05-18 17:47:47.596075+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('b5eacc09-715d-4711-a94e-d6907a036715', 'Home & Furniture', NULL, NULL, '2024-05-18 17:47:47.510554+00', 'guest', '2024-05-18 17:47:47.596075+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('ca143ecf-5ed8-4590-940e-dc640b96ceab', 'Toys & Games', NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', '2024-05-18 17:47:47.596075+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('d60f618e-ab99-49a8-aeb8-ecfce61d97de', 'Clothing & Apparel', NULL, NULL, '2024-05-18 17:47:47.510485+00', 'guest', '2024-05-18 17:47:47.59603+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('e262494d-c376-4247-97a8-5e150e119d13', 'Garden & Outdoor', NULL, NULL, '2024-05-18 17:47:47.510556+00', 'guest', '2024-05-18 17:47:47.596076+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('ea8a2d5f-8379-4e71-87da-bce75fc17d16', 'Health & Wellness', NULL, NULL, '2024-05-18 17:47:47.510556+00', 'guest', '2024-05-18 17:47:47.596076+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3', 'Jewelry & Accessories', NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', '2024-05-18 17:47:47.596076+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('fe47a271-d58b-4add-a178-804990c8bf95', 'Books & Stationery', NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', '2024-05-18 17:47:47.596075+00', 'guest', NULL);
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('019a7247-df32-4008-9fff-01f31d541785', 'Children''s Books', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'fe47a271-d58b-4add-a178-804990c8bf95');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('04fd44a3-d841-42f6-af7f-d84cd920f9bb', 'Bedding & Bath', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, 'b5eacc09-715d-4711-a94e-d6907a036715');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('0865c0f0-9144-41a9-ac94-1ffab3c71881', 'Lighting & Lamps', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, 'b5eacc09-715d-4711-a94e-d6907a036715');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('0f1519d6-5c3d-4db8-8095-dfee2170ad0e', 'Team Sports', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, '847724f7-03bd-425a-b38a-341e401eb4cb');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('1d165738-8e8e-42b0-92d5-bdecb182e111', 'Necklaces & Pendants', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('23b29dfe-f5ae-477f-82ef-629e33725aa1', 'Fragrances', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, '4015dd5c-56f8-484f-a2fb-1ddfeab73035');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('23d76458-6c7b-4205-8bfb-3244b1ba8db6', 'Pet Toys & Accessories', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, '1d2f34aa-543d-4708-b72b-8624914c3a84');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('252f5d8d-43cb-4231-9e88-301c8eb6b531', 'Garden Tools', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, 'e262494d-c376-4247-97a8-5e150e119d13');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('25e9db49-371c-4d45-ada8-d71a62b367e0', 'BBQ & Grilling', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, 'e262494d-c376-4247-97a8-5e150e119d13');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('2c5c56f1-2b95-42e1-aa4b-1c758b6a95f0', 'Grooming & Care', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, '1d2f34aa-543d-4708-b72b-8624914c3a84');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('2d70e4b0-3230-42b1-887e-ae8b63da179e', 'Fitness Trackers', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, 'ea8a2d5f-8379-4e71-87da-bce75fc17d16');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('2e6ebea9-fb3c-4a56-8b2d-3dac9e160bf3', 'Furniture', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, 'b5eacc09-715d-4711-a94e-d6907a036715');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('3238a575-c25b-4c15-8351-22fd9c7f1985', 'Car Care & Maintenance', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, '1c6ade43-ece6-43e2-a0fe-2181aac4b211');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('42519f07-809b-41b8-93df-34528072c70f', 'Bracelets & Bangles', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('46284733-925a-4d12-85cd-61a2b1653c26', 'Activewear', NULL, NULL, '2024-05-18 17:47:47.595867+00', 'guest', NULL, NULL, 'd60f618e-ab99-49a8-aeb8-ecfce61d97de');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('46749d17-d229-49dd-96c3-3a01444285b7', 'Accessories', NULL, NULL, '2024-05-18 17:47:47.595864+00', 'guest', NULL, NULL, 'd60f618e-ab99-49a8-aeb8-ecfce61d97de');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('50ef71aa-a63e-4c8c-b050-433b6820a5db', 'Earrings', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('53296808-359d-41e9-8ee7-4d9fe4ad42d8', 'Board Games', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'ca143ecf-5ed8-4590-940e-dc640b96ceab');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('59bda04f-e142-4121-8350-2f9f0f1d3681', 'Handbags & Wallets', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('5d0d5234-e8de-4beb-b777-444a57a48310', 'Puzzles', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'ca143ecf-5ed8-4590-940e-dc640b96ceab');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('60c90edf-2eab-4652-bf88-d8d767670fa4', 'Outdoor Furniture', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, 'e262494d-c376-4247-97a8-5e150e119d13');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('6121b1fe-430a-4f1d-b9cf-e775c29fdbcf', 'Men''s Clothing', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, 'd60f618e-ab99-49a8-aeb8-ecfce61d97de');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('6b8b2238-8898-4063-96ee-0a8172110e6c', 'Fiction & Literature', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'fe47a271-d58b-4add-a178-804990c8bf95');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('6c6fc0d6-831f-4c1a-8f85-97ee1af5b99d', 'Beds & Furniture', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, '1d2f34aa-543d-4708-b72b-8624914c3a84');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('6f8932c6-c6e4-4eae-9b0e-39ab04e2bfe5', 'Collectibles & Action Figures', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'ca143ecf-5ed8-4590-940e-dc640b96ceab');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('70f97b71-5697-4367-a503-2fc84f45f8bd', 'Office Supplies', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'fe47a271-d58b-4add-a178-804990c8bf95');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('7b04910b-e4a4-49a7-b099-5cf7af0b3134', 'Notebooks & Journals', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'fe47a271-d58b-4add-a178-804990c8bf95');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('7bd3a7e7-1155-42cb-b6c5-ccc15c303bd0', 'Plants & Seeds', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, 'e262494d-c376-4247-97a8-5e150e119d13');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('7d5fcb47-5c7b-4519-8d39-22086e194fb0', 'Laptops & Computers', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, '56d02381-f72c-46c8-987a-7a94d4713788');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('7e99db48-7678-4b1c-a929-5b520f75716a', 'Tools & Equipment', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, '1c6ade43-ece6-43e2-a0fe-2181aac4b211');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('84c6efbe-8b0d-452e-a08f-d108b0abe303', 'Skincare', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, '4015dd5c-56f8-484f-a2fb-1ddfeab73035');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('87bf969e-69a2-4de6-884b-957a90975898', 'Cameras & Photography', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, '56d02381-f72c-46c8-987a-7a94d4713788');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('8909cb76-fa56-48cb-8c1e-8debb1e8175e', 'Watches', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('8964aea6-e76f-4ba6-8197-782e3438915b', 'Pet Food', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, '1d2f34aa-543d-4708-b72b-8624914c3a84');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('8c7049cc-56cd-4958-bfd2-daea5c38a9be', 'Non-fiction', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'fe47a271-d58b-4add-a178-804990c8bf95');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('8d8e698b-efc0-485e-bed8-d4c75be688df', 'Sports Apparel', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, '847724f7-03bd-425a-b38a-341e401eb4cb');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('8ee9f994-9b77-482e-baa4-749d0dfec252', 'Shoes & Footwear', NULL, NULL, '2024-05-18 17:47:47.595867+00', 'guest', NULL, NULL, 'd60f618e-ab99-49a8-aeb8-ecfce61d97de');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('9acdd9b9-0344-47ed-8bdb-b70f7bb01ebd', 'Vitamins & Supplements', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, 'ea8a2d5f-8379-4e71-87da-bce75fc17d16');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('9b1ea0c9-abbc-4b46-811d-75cfca699f13', 'Haircare', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, '4015dd5c-56f8-484f-a2fb-1ddfeab73035');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('9f7cb916-44d6-43f8-9359-ef16e27187f0', 'Personal Care & Hygiene', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, '4015dd5c-56f8-484f-a2fb-1ddfeab73035');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('a1e9ecde-4924-4a28-a38b-a4d6f75b104c', 'Outdoor Play', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'ca143ecf-5ed8-4590-940e-dc640b96ceab');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('a3fb01d7-da6b-4c14-8ca3-78139bf29b7d', 'Car Parts & Accessories', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, '1c6ade43-ece6-43e2-a0fe-2181aac4b211');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('a64d6d77-925a-4747-aadc-9d1f3789311b', 'Phones', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, '56d02381-f72c-46c8-987a-7a94d4713788');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('a770dfd5-739d-4d8e-b80f-4e6b5820dc70', 'Home Decor', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, 'b5eacc09-715d-4711-a94e-d6907a036715');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('a823c204-c249-43f0-b150-e12b686122ea', 'Tablets & E-readers', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, '56d02381-f72c-46c8-987a-7a94d4713788');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('b678aead-5943-4442-ba7a-3271e9b8bd18', 'Makeup & Cosmetics', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, '4015dd5c-56f8-484f-a2fb-1ddfeab73035');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('cacb0b94-866d-450d-9bcc-b4a8e3564036', 'Kitchen & Dining', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, 'b5eacc09-715d-4711-a94e-d6907a036715');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('ce6de851-2a43-4c86-bc0b-a2095682c760', 'Personal Care', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, 'ea8a2d5f-8379-4e71-87da-bce75fc17d16');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('d13c5a64-fef9-4049-a462-20b64b2e1c69', 'Toys for Kids', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, 'ca143ecf-5ed8-4590-940e-dc640b96ceab');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('dbdd5e42-358a-4446-925f-dbe665c8881d', 'Wearable Technology', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, '56d02381-f72c-46c8-987a-7a94d4713788');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('dc6dcf2b-cb99-4802-a2f3-4f661ae61006', 'Cycling & Biking', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL, '847724f7-03bd-425a-b38a-341e401eb4cb');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('e392858b-8c57-4551-b3f7-35f39953a8d6', 'Outdoor Gear', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, '847724f7-03bd-425a-b38a-341e401eb4cb');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('e4c60534-efc7-40dc-bfa6-3948fe399bd9', 'Electronics & Gadgets', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL, '1c6ade43-ece6-43e2-a0fe-2181aac4b211');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('e7bb6bd6-eb16-45e1-a0f9-d7be33a9a8bf', 'Exercise & Fitness Equipment', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL, '847724f7-03bd-425a-b38a-341e401eb4cb');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('e9db7f4b-94de-4295-9dd0-ef0f7c9068e9', 'Health Monitors', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL, 'ea8a2d5f-8379-4e71-87da-bce75fc17d16');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('fbc6d751-5f98-4902-ba7d-9ca7a96f7a75', 'Women''s Clothing', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, 'd60f618e-ab99-49a8-aeb8-ecfce61d97de');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('fec7242e-5c91-4c0b-89ab-83ffab4dad8a', 'Kids & Baby Clothing', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, 'd60f618e-ab99-49a8-aeb8-ecfce61d97de');
INSERT INTO public."Categories" ("Id", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ParentId") VALUES ('fec84e69-89f3-4fec-a926-50e92ae5c048', 'Audio & Headphones', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL, '56d02381-f72c-46c8-987a-7a94d4713788');


--
-- Data for Name: ProductImages; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('467a7300-3323-43df-bb29-723366ae5601', 'https://cdn.chotot.com/ZINboETaouHBBBlydcuYj4sMQdUL37SJiWYYrYiev9Y/preset:view/plain/3f62832bafd084e1c081a37c51dc5238-2868277251139617617.jpg', '9f3af889-e4f4-4783-b656-2ae59bdd0ea8', NULL, NULL, '2024-05-18 18:00:03.851976+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('7ace79a3-ff82-4b36-a663-dc651678346e', 'https://cdn.chotot.com/AXbhSceSAXuLIeewlNYWdblst_eP0OHiEpf0DwJQpp4/preset:view/plain/d2ed968d68398c44a9b2ad23f0fcd587-2868277240205693416.jpg', '9f3af889-e4f4-4783-b656-2ae59bdd0ea8', NULL, NULL, '2024-05-18 18:00:03.85196+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('ac909377-ff34-4ea8-b886-2e52401777e4', 'https://cdn.chotot.com/j1SH4plUN0g3IC8WkURofG6_3KpHGNuqNVNW2-WKOuY/preset:view/plain/8b3dd31a7b2cfa8f44c1cb118068947a-2868277245680076034.jpg', '9f3af889-e4f4-4783-b656-2ae59bdd0ea8', NULL, NULL, '2024-05-18 18:00:03.851976+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('9ba1a2f0-772f-458e-ac12-50596e3f2622', 'https://cdn.chotot.com/tafazH5CqkMjTjYMogRA_xGTYCi3AogxMTjaUeBDybQ/preset:view/plain/0809792bddf0862e2971cb300c6ae25e-2871787427596711126.jpg', 'a4f2b029-81ee-401b-a94e-cf1395460eab', NULL, NULL, '2024-05-18 18:03:52.662206+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('b76820d7-364e-4b9d-8cc9-dd6d15675160', 'https://cdn.chotot.com/G5-1-hHbyc6qeoZS7nLUcNycqPyqyPaf6XsjK1yAMkE/preset:view/plain/db6dc97ec3724e9337ce3b9bba881c27-2871787427681450210.jpg', 'a4f2b029-81ee-401b-a94e-cf1395460eab', NULL, NULL, '2024-05-18 18:03:52.662205+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('fc114190-cf24-4d55-8503-377d4395d8e8', 'https://cdn.chotot.com/qdm3QQc9GzUPaDVL1XXZaZBFxI1rWKUbtNiKc0-TaMs/preset:view/plain/ee5131f0927dfd1623ce1ea643ea23ed-2871787428319321200.jpg', 'a4f2b029-81ee-401b-a94e-cf1395460eab', NULL, NULL, '2024-05-18 18:03:52.662205+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('5bf96de8-2aa0-4e25-bd16-78242736e630', 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmcn2dy8qj1bf5', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', NULL, NULL, '2024-05-19 05:22:21.457079+00', 'user1@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('8cf8603a-e14a-4a27-a361-bf7d309513d8', 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmcn2dy8tc674e', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', NULL, NULL, '2024-05-19 05:22:21.457079+00', 'user1@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('8ee28158-a8c3-4c15-9a9b-7672454acc13', 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmcn2dy8tc674e', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', NULL, NULL, '2024-05-19 05:22:21.457079+00', 'user1@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('ab2c27f1-996f-42d2-9fd1-f8d3e6fa2e7b', 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmcn2dy8xjvj03', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', NULL, NULL, '2024-05-19 05:22:21.45708+00', 'user1@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('ae2063e3-708b-43e5-819d-e3cd8acc812f', 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmcn2dy8w5b319', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', NULL, NULL, '2024-05-19 05:22:21.45708+00', 'user1@123', NULL, NULL);
INSERT INTO public."ProductImages" ("Id", "Url", "ProductId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('d5848da4-9aab-4f86-8194-adfbbe020697', 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmcn2dy8rxlr63', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', NULL, NULL, '2024-05-19 05:22:21.457079+00', 'user1@123', NULL, NULL);


--
-- Data for Name: ProductTypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Quantity", "Price", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ImageUrl") VALUES ('b6148f5b-3e5c-4e86-afef-b1b710d3ea6f', '9f3af889-e4f4-4783-b656-2ae59bdd0ea8', 'Đen', 100, 15750000, NULL, NULL, '2024-05-18 18:00:03.851977+00', 'user@123', NULL, NULL, 'https://cdn.chotot.com/_mL0_vk_rtVsinuxMyeRL-LUSMTR7uO4ca4200SeVE0/preset:view/plain/cba7bb82e3946be8a2e051f038682b5d-2868277221040571217.jpg');
INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Quantity", "Price", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ImageUrl") VALUES ('2bfea01b-3abe-4cdb-b10a-6cbd561e1894', 'a4f2b029-81ee-401b-a94e-cf1395460eab', '𝐌𝐢𝐝𝐧𝐢𝐠𝐡𝐭', 10, 21900000, NULL, NULL, '2024-05-18 18:03:52.662206+00', 'user@123', NULL, NULL, 'https://cdn.chotot.com/KUQgefOZ6r0hoC8Zu8W57QKfsxiK0athhSZv0RlCM6M/preset:view/plain/e6af379f5d1bba63a07b857709b04a86-2871787396088640726.jpg');
INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Quantity", "Price", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ImageUrl") VALUES ('54ea6cec-ee96-4895-88e6-2b6bce3aad3c', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', 'M550 Size L (Đen)', 424, 579000, NULL, NULL, '2024-05-19 05:22:21.45708+00', 'user1@123', NULL, NULL, 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-loqjogt58u341d');
INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Quantity", "Price", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "ImageUrl") VALUES ('9652cb3b-40bf-4707-a949-bd12185ad428', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', 'M550 Đen (M)', 437, 579000, NULL, NULL, '2024-05-19 05:22:21.45708+00', 'user1@123', '2024-05-19 13:30:44.898116+00', 'guest', 'https://down-vn.img.susercontent.com/file/vn-50009109-d65d063bea9062423edb7e4e9088930c');


--
-- Data for Name: Products; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Products" ("Id", "UserId", "Name", "Description", "CategoryId", "Sold", "Condition", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('9f3af889-e4f4-4783-b656-2ae59bdd0ea8', 'd60dff58-0eea-4c64-a5e3-0b1d32cded75', 'Máy Game STEAM DECK OLED 512GB LƯỚT FULLBOX xịnnn✨', 'Máy chơi game 𝗦𝘁𝗲𝗮𝗺 𝗗𝗲𝗰𝗸 𝗢𝗟𝗘𝗗 𝟱𝟭𝟮𝗚𝗕 lướt còn mới 99% Fullbox ✨✨✨
| 💸 Giá: 15.750.000 VNĐ | - Tặng cường lực chống rơi vỡ
Bao test 30 ngày - Bảo hành 6 tháng tại Masta shop

▪️ Cấu hình:
Chi tiết CPU: Zen 2 4c/8t, 2.4-3.5GHz (lên tới 448 GFlops FP32)
Hỗ trợ thẻ nhớ UHS-I hỗ trợ SD, SDXC và SDHC
Hệ điều hành SteamOS 3 (dựa trên Arch Linux)
Độ phân giải 1280 x 800 x RGB
Kích thước màn hình 7.4-inch
Kích thước 298mm x 117mm x 49mm
Khối lượng khoảng 640 gram
Dung lượng Pin 50Wh; 3 - 12 giờ chơi
Nguồn điện PD 3.0 cổng USB-C, 45W Cáp 2,5m
----------------------------------------------------
Trả góp 0% chỉ cần CCCD - Bao đậu với tiêu chí 3 KHÔNG
❌KHÔNG gọi cho người thân.
❌KHÔNG chứng minh thu nhập.
❌KHÔNG giữ giấy tờ gốc.
-----------------------------------------------------
𝐌𝐀𝐒𝐓𝐀 𝐒𝐇𝐎𝐏 - BEST SELLER UY TÍN TOP 1 HCM
Địa chỉ: 601 Nguyễn Đình Chiểu, P2, Quận 3, Hồ Chí Minh
#steamdeckOled #handheld #maygamecamtay #SteamDeck #gameconsole #maygamesteamdeckoled', 'a823c204-c249-43f0-b150-e12b686122ea', 0, 1, NULL, NULL, '2024-05-18 18:00:03.85191+00', 'user@123', NULL, NULL);
INSERT INTO public."Products" ("Id", "UserId", "Name", "Description", "CategoryId", "Sold", "Condition", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('a4f2b029-81ee-401b-a94e-cf1395460eab', 'd60dff58-0eea-4c64-a5e3-0b1d32cded75', '𝐌𝐚𝐜𝐛𝐨𝐨𝐤 𝐀𝐢𝐫 𝟏𝟑 𝐌𝐢𝐝𝐧𝐢𝐠𝐡𝐭 𝟐𝟎𝟐𝟑 𝐌𝟐/𝟖/𝟐𝟓𝟔 𝐎𝐩𝐞𝐧𝐛𝐨𝐱', '👉 𝐌𝐋𝐘𝟑𝟑 𝐌𝐚𝐜𝐛𝐨𝐨𝐤 𝐀𝐢𝐫 𝟏𝟑 𝐢𝐧𝐜𝐡 𝐌𝐢𝐝𝐧𝐢𝐠𝐡𝐭 𝟐𝟎𝟐𝟑 - (𝐌𝟐/𝟖/𝟐𝟓𝟔) - 𝐌𝐚́𝐲 𝐎𝐩𝐞𝐧𝐛𝐨𝐱 (𝐜𝐚̣̂𝐧 𝐧𝐞𝐰, 𝐬𝐚̣𝐜 𝐝𝐮̛𝐨̛́𝐢 𝐯𝐚̀𝐢 𝐥𝐚̂̀𝐧) 𝐤𝐡𝐨̂𝐧𝐠 𝐤𝐡𝐚́𝐜 𝐠𝐢̀ 𝐦𝐚́𝐲 𝐦𝐨̛́𝐢)

▪️ 𝐌𝐀𝐂𝐁𝐎𝐎𝐊 𝐥𝐮̛𝐨̛́𝐭 𝐜𝐨̀𝐧 𝐦𝐨̛́𝐢 𝟗𝟗% - 𝐁𝐚̉𝐨 𝐡𝐚̀𝐧𝐡 𝟎𝟔 𝐭𝐡𝐚́𝐧𝐠 , 𝐛𝐚𝐨 𝐱𝐚̀𝐢 , 𝐛𝐚𝐨 𝐭𝐞𝐬𝐭 𝐭𝐡𝐨𝐚̉𝐢 𝐦𝐚́𝐢 𝐭𝐫𝐨𝐧𝐠 𝟏 𝐭𝐡𝐚́𝐧𝐠

▪️ Máy fullbox, sạc cáp đầy đủ, cận new, sạc vài lần) không khác gì máy mới
| 💸 Giá: 21.900.000 VNĐ | Máy VN new giờ 27.x

𝑨̉𝒏𝒉 𝒕𝒉𝒖̛̣𝒄 𝒕𝒆̂́ 𝒄𝒉𝒊 𝒕𝒊𝒆̂́𝒕 𝒅𝒖̛𝒐̛́𝒊 𝒃𝒂̀𝒊 𝒖𝒑, 𝒌𝒉𝒂́𝒄𝒉 𝒄𝒂̂̀𝒏 𝒕𝒉𝒆̂𝒎 𝒕𝒉𝒐̂𝒏𝒈 𝒕𝒊𝒏 𝒗𝒖𝒊 𝒍𝒐̀𝒏𝒈 𝒊𝒃 𝒄𝒉𝒐 𝒔𝒉𝒐𝒑 𝒂̣ !
♥️ 𝙉𝙂𝙊𝘼̀𝙄 𝙍𝘼 𝘾𝙊̀𝙉 𝙏𝘼̣̆𝙉𝙂 𝙁𝙐𝙇𝙇 𝘾𝙊𝙈𝘽𝙊 𝙌𝙐𝘼̀ 𝙏𝘼̣̆𝙉𝙂 ♥️
------------------------------------
Quà tặng:
🎁 Túi chống sốc
🎁 Chuột máy tính
🎁 Miếng lót chuột
🎁 Khách mua tặng FREE gói quà
🎁 Thu cũ đổi mới - Hỗ trợ khách yêu lên đời
BẢO HÀNH 09 THÁNG , 1 ĐỔI 1 TRONG 30 NGÀY
--------------------------------------
Trả góp 0% chỉ cần CCCD - Bao đậu với tiêu chí 3 KHÔNG
KHÔNG gọi cho người thân.
KHÔNG chứng minh thu nhập.
KHÔNG giữ giấy tờ gốc.
---------------------------------------
𝐌𝐀𝐒𝐓𝐀 𝐒𝐇𝐎𝐏 - BEST SELLER UY TÍN TOP 1 HCM
Địa chỉ: 601 Nguyễn Đình Chiểu, P2, Quận 3', 'a823c204-c249-43f0-b150-e12b686122ea', 0, 1, NULL, NULL, '2024-05-18 18:03:52.6622+00', 'user@123', NULL, NULL);
INSERT INTO public."Products" ("Id", "UserId", "Name", "Description", "CategoryId", "Sold", "Condition", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', 'dbfef7a2-bb00-43e8-b112-b35736fe4d9d', 'Chuột không dây Bluetooth Logitech M550 Signature - SmartWheel, giảm ồn, 4000DPI, Đa thiết bị', 'Nâng cấp để cuộn thông minh hơn, thoải mái hơn và năng suất cao hơn với chuột không dây Bluetooth chống ồn Logitech Signature M550

Chuột đa M550 Blueooth với công nghệ SmartWheel cuộn thông minh mang lại độ chính xác đến từng dòng và tự động chuyển sang chế độ quay tự do siêu nhanh chỉ bằng một cú chạm ngón tay. Thiết kế phù hợp với bàn tay nhỏ đến trung bình kiểu dáng thoải mái giúp bạn luôn thoải mái và làm việc hiệu quả hàng giờ. Công nghệ SilentTouch của Logitech mang đến những cú nhấp chuột im lặng giúp bạn tập trung, thời lượng pin 24 tháng và khả năng tương thích hệ điều hành đa hệ điều hành bao gồm cả MacOS 

Tính năng cuộn thông minh SmartWheel đặc trưng : 

Với Chuột không dây Logitech Signature M550, bạn có được độ chính xác từng dòng cho tài liệu và cuộn cực nhanh cho các trang web dài; chỉ cần chuyển đổi chế độ bằng một cái chạm nhẹ vào SmartWheel

Kích Thước Nhỏ Gọn, phù hợp tối ưu cho bàn tay của bạn:

Con chuột thoải mái này được thiết kế cho bàn tay có kích thước vừa và nhỏ để có độ vừa vặn tối ưu

Dễ dàng chuyển đổi giữa 3 thiết bị: 

Sử dụng Bluetooth để kết nối lên tới 3 thiết bị không dây trên các hệ điều hành và chuyển đổi giữa chúng bằng một cú nhấp vào nút Easy-Switch; Đi kèm đầu thu USB Logi Bolt

Nâng cấp sự thoải mái của bạn:

Con chuột làm việc này mang lại sự thoải mái trong nhiều giờ nhờ hình dạng có đường viền, khu vực ngón tay cái mềm mại và tay cầm bên hông bằng cao su giúp bàn tay của bạn luôn ở đúng vị trí

Ít tiếng ồn hơn, tập trung hơn:

Dù làm việc tại văn phòng hay ở nhà, Logitech Signature M550 Size M đều là con chuột yên tĩnh, cho phép bạn tận hưởng tiếng ồn khi nhấp chuột ít hơn 90% với công nghệ SilentTouch

Hoạt động trên nhiều nền tảng:

Trải nghiệm khả năng tương thích liền mạch với các hệ điều hành Windows, macOS, Linux, Chrome OS, ipadOS và Android với chuột Bluetooth không dây Logitech Signature M550

TÓM TẮT TÍNH NĂNG 

- Cuộn SmartWheel để có độ chính xác khi bạn cần và tăng tốc ngay lập tức.

- Tùy chọn kích thước cho bàn tay nhỏ hơn và lớn hơn

- Hình dáng thoải mái với vùng ngón tay cái mềm mại

- Kết nối qua bộ thu Bluetooth Low Energy hoặc Logi Bolt

- Giảm 90% tiếng ồn khi nhấp chuột với công nghệ SilentTouch

- Tuổi thọ pin 24 tháng

- Tương thích đa hệ điều hành  Windows, macOS, Linux, Chrome OS, ipadOS và Android

THÔNG SỐ KỸ THUẬT

Kích thước

Chuột

Dài x Rộng x Cao :  38.8 x 61 x 108.2 mm

Nặng  97.4 g (khi đi kèm với Pin)

Pin:

1 AA batteries (Alkaline Battery)

Logi Bolt USB đầu thu

- Dài x Rộng x Cao : 14.4 x 18.7 x 6.1 mm

- Nặng : 1.8 g

- Công nghệ SilentTouch

- Hình dạng đường viền nhỏ gọn

- Điều khiển con trỏ mượt mà, nhạy bén

- Nút nguồn bật/tắt

YÊU CẦU KĨ THUẬT

Bluetooth® công nghệ tiết kiệm năng lượng

- Đầu thu Logi Bolt

Yêu cầu truy cập Internet để tải về ứng dụng tùy chỉnh tùy chọn Logi Options+

Đầu thu USB Logi Bolt

Yêu cầu: Cổng USB-A

Windows 10, 11 trở lên (1)

macOS 11 trở lên (1)

Linux (2)

Chrome OS (2)

- Bluetooth®

Yêu cầu: Bluetooth Low Energy

Windows 10, 11 trở lên

macOS 11 trở lên 

Linux 

Chrome OS

iPadOS 14 trở lên

iOS 14 trở lên 

Android 9.0 trở lên 

Hoạt động với Chromebook 

THÔNG TIN BẢO HÀNH 

Bảo hành phần cứng chính hãng Logitech trong 1 năm

TRONG HỘP BAO GỒM 

 Logitech Signature M550 Size M

 1 pin AA (có sẵn) dành cho chuột

 1 USB Receiver Logi Bolt

- Tài liệu hướng dẫn sử dụng', '7d5fcb47-5c7b-4519-8d39-22086e194fb0', 1, 0, NULL, NULL, '2024-05-19 05:22:21.457076+00', 'user1@123', '2024-05-19 13:30:44.898096+00', 'guest');


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231120135019_InitializeProductTables', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231120144335_RemoveProductAndAddProductTypeToProductImageRelationship', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231121030452_AddMinPriceAndMaxPriceColumnToProductsTable', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231121142140_RemoveProductTypeAndAddProductToProductImageRelationship', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231129142744_InitializeUserConfiguration', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231130032816_AddCoverUrlColumnToUsersTable', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231201100608_ApplyCategoriesTableConfiguration', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231202081503_AddSelfRelationshipToCategoriesTable', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231203094512_RemoveIrrelevantColumnsFromProductsTable', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231203132807_RemoveUsersTable', '7.0.10');


--
-- Name: Categories PK_Categories; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "PK_Categories" PRIMARY KEY ("Id");


--
-- Name: ProductImages PK_ProductImages; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProductImages"
    ADD CONSTRAINT "PK_ProductImages" PRIMARY KEY ("Id");


--
-- Name: ProductTypes PK_ProductTypes; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProductTypes"
    ADD CONSTRAINT "PK_ProductTypes" PRIMARY KEY ("Id");


--
-- Name: Products PK_Products; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "PK_Products" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_Categories_ParentId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Categories_ParentId" ON public."Categories" USING btree ("ParentId");


--
-- Name: IX_ProductImages_ProductId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_ProductImages_ProductId" ON public."ProductImages" USING btree ("ProductId");


--
-- Name: IX_ProductTypes_ProductId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_ProductTypes_ProductId" ON public."ProductTypes" USING btree ("ProductId");


--
-- Name: IX_Products_CategoryId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Products_CategoryId" ON public."Products" USING btree ("CategoryId");


--
-- Name: Categories FK_Categories_Categories_ParentId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "FK_Categories_Categories_ParentId" FOREIGN KEY ("ParentId") REFERENCES public."Categories"("Id");


--
-- Name: ProductImages FK_ProductImages_Products_ProductId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProductImages"
    ADD CONSTRAINT "FK_ProductImages_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES public."Products"("Id") ON DELETE CASCADE;


--
-- Name: ProductTypes FK_ProductTypes_Products_ProductId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProductTypes"
    ADD CONSTRAINT "FK_ProductTypes_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES public."Products"("Id") ON DELETE CASCADE;


--
-- Name: Products FK_Products_Categories_CategoryId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "FK_Products_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES public."Categories"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

