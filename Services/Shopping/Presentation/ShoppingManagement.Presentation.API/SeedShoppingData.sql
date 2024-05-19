drop table "__EFMigrationsHistory" cascade;

drop table "ProductImages" cascade;

drop table "Cart" cascade;

drop table "ProductTypes" cascade;

drop table "Products" cascade;

drop table "Categories" cascade;

drop table "Users" cascade;

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
-- Name: Cart; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Cart" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "ProductTypeId" uuid NOT NULL,
    "Quantity" integer DEFAULT 1 NOT NULL,
    "TotalPrice" double precision NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
);


ALTER TABLE public."Cart" OWNER TO postgres;

--
-- Name: Categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Categories" (
    "Id" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "ParentId" uuid,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
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
    "ImageUrl" text,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
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
    "Rating" double precision NOT NULL,
    "TotalReviews" integer NOT NULL,
    "Condition" integer NOT NULL,
    "MinPrice" double precision NOT NULL,
    "MaxPrice" double precision NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
);


ALTER TABLE public."Products" OWNER TO postgres;

--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "Name" character varying(320) NOT NULL,
    "AverageRating" double precision DEFAULT 0.0 NOT NULL,
    "AvatarUrl" text,
    "CoverUrl" text,
    "ProductSold" integer DEFAULT 0 NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Data for Name: Cart; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: Categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('56d02381-f72c-46c8-987a-7a94d4713788', 'Electronics', NULL, NULL, NULL, '2024-05-18 17:47:47.509985+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('a64d6d77-925a-4747-aadc-9d1f3789311b', 'Phones', '56d02381-f72c-46c8-987a-7a94d4713788', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('a823c204-c249-43f0-b150-e12b686122ea', 'Tablets & E-readers', '56d02381-f72c-46c8-987a-7a94d4713788', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('7d5fcb47-5c7b-4519-8d39-22086e194fb0', 'Laptops & Computers', '56d02381-f72c-46c8-987a-7a94d4713788', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('fec84e69-89f3-4fec-a926-50e92ae5c048', 'Audio & Headphones', '56d02381-f72c-46c8-987a-7a94d4713788', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('87bf969e-69a2-4de6-884b-957a90975898', 'Cameras & Photography', '56d02381-f72c-46c8-987a-7a94d4713788', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('dbdd5e42-358a-4446-925f-dbe665c8881d', 'Wearable Technology', '56d02381-f72c-46c8-987a-7a94d4713788', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('d60f618e-ab99-49a8-aeb8-ecfce61d97de', 'Clothing & Apparel', NULL, NULL, NULL, '2024-05-18 17:47:47.510485+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('6121b1fe-430a-4f1d-b9cf-e775c29fdbcf', 'Men''s Clothing', 'd60f618e-ab99-49a8-aeb8-ecfce61d97de', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('fbc6d751-5f98-4902-ba7d-9ca7a96f7a75', 'Women''s Clothing', 'd60f618e-ab99-49a8-aeb8-ecfce61d97de', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('fec7242e-5c91-4c0b-89ab-83ffab4dad8a', 'Kids & Baby Clothing', 'd60f618e-ab99-49a8-aeb8-ecfce61d97de', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('8ee9f994-9b77-482e-baa4-749d0dfec252', 'Shoes & Footwear', 'd60f618e-ab99-49a8-aeb8-ecfce61d97de', NULL, NULL, '2024-05-18 17:47:47.595867+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('46284733-925a-4d12-85cd-61a2b1653c26', 'Activewear', 'd60f618e-ab99-49a8-aeb8-ecfce61d97de', NULL, NULL, '2024-05-18 17:47:47.595867+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('46749d17-d229-49dd-96c3-3a01444285b7', 'Accessories', 'd60f618e-ab99-49a8-aeb8-ecfce61d97de', NULL, NULL, '2024-05-18 17:47:47.595864+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('b5eacc09-715d-4711-a94e-d6907a036715', 'Home & Furniture', NULL, NULL, NULL, '2024-05-18 17:47:47.510554+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('2e6ebea9-fb3c-4a56-8b2d-3dac9e160bf3', 'Furniture', 'b5eacc09-715d-4711-a94e-d6907a036715', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('a770dfd5-739d-4d8e-b80f-4e6b5820dc70', 'Home Decor', 'b5eacc09-715d-4711-a94e-d6907a036715', NULL, NULL, '2024-05-18 17:47:47.595868+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('04fd44a3-d841-42f6-af7f-d84cd920f9bb', 'Bedding & Bath', 'b5eacc09-715d-4711-a94e-d6907a036715', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('cacb0b94-866d-450d-9bcc-b4a8e3564036', 'Kitchen & Dining', 'b5eacc09-715d-4711-a94e-d6907a036715', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('0865c0f0-9144-41a9-ac94-1ffab3c71881', 'Lighting & Lamps', 'b5eacc09-715d-4711-a94e-d6907a036715', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('4015dd5c-56f8-484f-a2fb-1ddfeab73035', 'Beauty & Personal Care', NULL, NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('84c6efbe-8b0d-452e-a08f-d108b0abe303', 'Skincare', '4015dd5c-56f8-484f-a2fb-1ddfeab73035', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('9b1ea0c9-abbc-4b46-811d-75cfca699f13', 'Haircare', '4015dd5c-56f8-484f-a2fb-1ddfeab73035', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('b678aead-5943-4442-ba7a-3271e9b8bd18', 'Makeup & Cosmetics', '4015dd5c-56f8-484f-a2fb-1ddfeab73035', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('23b29dfe-f5ae-477f-82ef-629e33725aa1', 'Fragrances', '4015dd5c-56f8-484f-a2fb-1ddfeab73035', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('9f7cb916-44d6-43f8-9359-ef16e27187f0', 'Personal Care & Hygiene', '4015dd5c-56f8-484f-a2fb-1ddfeab73035', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('847724f7-03bd-425a-b38a-341e401eb4cb', 'Sports & Outdoors', NULL, NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('e7bb6bd6-eb16-45e1-a0f9-d7be33a9a8bf', 'Exercise & Fitness Equipment', '847724f7-03bd-425a-b38a-341e401eb4cb', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('8d8e698b-efc0-485e-bed8-d4c75be688df', 'Sports Apparel', '847724f7-03bd-425a-b38a-341e401eb4cb', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('e392858b-8c57-4551-b3f7-35f39953a8d6', 'Outdoor Gear', '847724f7-03bd-425a-b38a-341e401eb4cb', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('0f1519d6-5c3d-4db8-8095-dfee2170ad0e', 'Team Sports', '847724f7-03bd-425a-b38a-341e401eb4cb', NULL, NULL, '2024-05-18 17:47:47.595869+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('dc6dcf2b-cb99-4802-a2f3-4f661ae61006', 'Cycling & Biking', '847724f7-03bd-425a-b38a-341e401eb4cb', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('ca143ecf-5ed8-4590-940e-dc640b96ceab', 'Toys & Games', NULL, NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('d13c5a64-fef9-4049-a462-20b64b2e1c69', 'Toys for Kids', 'ca143ecf-5ed8-4590-940e-dc640b96ceab', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('53296808-359d-41e9-8ee7-4d9fe4ad42d8', 'Board Games', 'ca143ecf-5ed8-4590-940e-dc640b96ceab', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('5d0d5234-e8de-4beb-b777-444a57a48310', 'Puzzles', 'ca143ecf-5ed8-4590-940e-dc640b96ceab', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('a1e9ecde-4924-4a28-a38b-a4d6f75b104c', 'Outdoor Play', 'ca143ecf-5ed8-4590-940e-dc640b96ceab', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('6f8932c6-c6e4-4eae-9b0e-39ab04e2bfe5', 'Collectibles & Action Figures', 'ca143ecf-5ed8-4590-940e-dc640b96ceab', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('fe47a271-d58b-4add-a178-804990c8bf95', 'Books & Stationery', NULL, NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('6b8b2238-8898-4063-96ee-0a8172110e6c', 'Fiction & Literature', 'fe47a271-d58b-4add-a178-804990c8bf95', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('8c7049cc-56cd-4958-bfd2-daea5c38a9be', 'Non-fiction', 'fe47a271-d58b-4add-a178-804990c8bf95', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('019a7247-df32-4008-9fff-01f31d541785', 'Children''s Books', 'fe47a271-d58b-4add-a178-804990c8bf95', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('70f97b71-5697-4367-a503-2fc84f45f8bd', 'Office Supplies', 'fe47a271-d58b-4add-a178-804990c8bf95', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('7b04910b-e4a4-49a7-b099-5cf7af0b3134', 'Notebooks & Journals', 'fe47a271-d58b-4add-a178-804990c8bf95', NULL, NULL, '2024-05-18 17:47:47.59587+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3', 'Jewelry & Accessories', NULL, NULL, NULL, '2024-05-18 17:47:47.510555+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('1d165738-8e8e-42b0-92d5-bdecb182e111', 'Necklaces & Pendants', 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('50ef71aa-a63e-4c8c-b050-433b6820a5db', 'Earrings', 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('42519f07-809b-41b8-93df-34528072c70f', 'Bracelets & Bangles', 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('8909cb76-fa56-48cb-8c1e-8debb1e8175e', 'Watches', 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('59bda04f-e142-4121-8350-2f9f0f1d3681', 'Handbags & Wallets', 'fd4a62b8-84e9-4de9-b5b7-2aa0402e8eb3', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('ea8a2d5f-8379-4e71-87da-bce75fc17d16', 'Health & Wellness', NULL, NULL, NULL, '2024-05-18 17:47:47.510556+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('9acdd9b9-0344-47ed-8bdb-b70f7bb01ebd', 'Vitamins & Supplements', 'ea8a2d5f-8379-4e71-87da-bce75fc17d16', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('2d70e4b0-3230-42b1-887e-ae8b63da179e', 'Fitness Trackers', 'ea8a2d5f-8379-4e71-87da-bce75fc17d16', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('e9db7f4b-94de-4295-9dd0-ef0f7c9068e9', 'Health Monitors', 'ea8a2d5f-8379-4e71-87da-bce75fc17d16', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('ce6de851-2a43-4c86-bc0b-a2095682c760', 'Personal Care', 'ea8a2d5f-8379-4e71-87da-bce75fc17d16', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('1c6ade43-ece6-43e2-a0fe-2181aac4b211', 'Automotive', NULL, NULL, NULL, '2024-05-18 17:47:47.510556+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('a3fb01d7-da6b-4c14-8ca3-78139bf29b7d', 'Car Parts & Accessories', '1c6ade43-ece6-43e2-a0fe-2181aac4b211', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('7e99db48-7678-4b1c-a929-5b520f75716a', 'Tools & Equipment', '1c6ade43-ece6-43e2-a0fe-2181aac4b211', NULL, NULL, '2024-05-18 17:47:47.595871+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('3238a575-c25b-4c15-8351-22fd9c7f1985', 'Car Care & Maintenance', '1c6ade43-ece6-43e2-a0fe-2181aac4b211', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('e4c60534-efc7-40dc-bfa6-3948fe399bd9', 'Electronics & Gadgets', '1c6ade43-ece6-43e2-a0fe-2181aac4b211', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('1d2f34aa-543d-4708-b72b-8624914c3a84', 'Pet Supplies', NULL, NULL, NULL, '2024-05-18 17:47:47.510556+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('8964aea6-e76f-4ba6-8197-782e3438915b', 'Pet Food', '1d2f34aa-543d-4708-b72b-8624914c3a84', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('23d76458-6c7b-4205-8bfb-3244b1ba8db6', 'Pet Toys & Accessories', '1d2f34aa-543d-4708-b72b-8624914c3a84', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('6c6fc0d6-831f-4c1a-8f85-97ee1af5b99d', 'Beds & Furniture', '1d2f34aa-543d-4708-b72b-8624914c3a84', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('2c5c56f1-2b95-42e1-aa4b-1c758b6a95f0', 'Grooming & Care', '1d2f34aa-543d-4708-b72b-8624914c3a84', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('e262494d-c376-4247-97a8-5e150e119d13', 'Garden & Outdoor', NULL, NULL, NULL, '2024-05-18 17:47:47.510556+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('7bd3a7e7-1155-42cb-b6c5-ccc15c303bd0', 'Plants & Seeds', 'e262494d-c376-4247-97a8-5e150e119d13', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('60c90edf-2eab-4652-bf88-d8d767670fa4', 'Outdoor Furniture', 'e262494d-c376-4247-97a8-5e150e119d13', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('252f5d8d-43cb-4231-9e88-301c8eb6b531', 'Garden Tools', 'e262494d-c376-4247-97a8-5e150e119d13', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);
INSERT INTO public."Categories" ("Id", "Name", "ParentId", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('25e9db49-371c-4d45-ada8-d71a62b367e0', 'BBQ & Grilling', 'e262494d-c376-4247-97a8-5e150e119d13', NULL, NULL, '2024-05-18 17:47:47.595872+00', 'guest', NULL, NULL);


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

INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Quantity", "Price", "ImageUrl", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('b6148f5b-3e5c-4e86-afef-b1b710d3ea6f', '9f3af889-e4f4-4783-b656-2ae59bdd0ea8', 'Đen', 100, 15750000, 'https://cdn.chotot.com/_mL0_vk_rtVsinuxMyeRL-LUSMTR7uO4ca4200SeVE0/preset:view/plain/cba7bb82e3946be8a2e051f038682b5d-2868277221040571217.jpg', NULL, NULL, '2024-05-18 18:00:03.851977+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Quantity", "Price", "ImageUrl", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('2bfea01b-3abe-4cdb-b10a-6cbd561e1894', 'a4f2b029-81ee-401b-a94e-cf1395460eab', '𝐌𝐢𝐝𝐧𝐢𝐠𝐡𝐭', 10, 21900000, 'https://cdn.chotot.com/KUQgefOZ6r0hoC8Zu8W57QKfsxiK0athhSZv0RlCM6M/preset:view/plain/e6af379f5d1bba63a07b857709b04a86-2871787396088640726.jpg', NULL, NULL, '2024-05-18 18:03:52.662206+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Quantity", "Price", "ImageUrl", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('54ea6cec-ee96-4895-88e6-2b6bce3aad3c', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', 'M550 Size L (Đen)', 424, 579000, 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-loqjogt58u341d', NULL, NULL, '2024-05-19 05:22:21.45708+00', 'user1@123', NULL, NULL);
INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Quantity", "Price", "ImageUrl", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('9652cb3b-40bf-4707-a949-bd12185ad428', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', 'M550 Đen (M)', 437, 579000, 'https://down-vn.img.susercontent.com/file/vn-50009109-d65d063bea9062423edb7e4e9088930c', NULL, NULL, '2024-05-19 05:22:21.45708+00', 'user1@123', '2024-05-19 13:30:44.913256+00', 'guest');


--
-- Data for Name: Products; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Products" ("Id", "UserId", "Name", "Description", "CategoryId", "Sold", "Rating", "TotalReviews", "Condition", "MinPrice", "MaxPrice", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('9f3af889-e4f4-4783-b656-2ae59bdd0ea8', 'd60dff58-0eea-4c64-a5e3-0b1d32cded75', 'Máy Game STEAM DECK OLED 512GB LƯỚT FULLBOX xịnnn✨', 'ádasdbaskfbkfbadslkoahuasiodkjlam,s.đá', 'a823c204-c249-43f0-b150-e12b686122ea', 0, 0, 0, 1, 15750000, 15750000, NULL, NULL, '2024-05-18 18:00:03.85191+00', 'user@123', NULL, NULL);
INSERT INTO public."Products" ("Id", "UserId", "Name", "Description", "CategoryId", "Sold", "Rating", "TotalReviews", "Condition", "MinPrice", "MaxPrice", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('a4f2b029-81ee-401b-a94e-cf1395460eab', 'd60dff58-0eea-4c64-a5e3-0b1d32cded75', '𝐌𝐚𝐜𝐛𝐨𝐨𝐤 𝐀𝐢𝐫 𝟏𝟑 𝐌𝐢𝐝𝐧𝐢𝐠𝐡𝐭 𝟐𝟎𝟐𝟑 𝐌𝟐/𝟖/𝟐𝟓𝟔 𝐎𝐩𝐞𝐧𝐛𝐨𝐱', 'ádasdbaskfbkfbadslkoahuasiodkjlam,s.đá', 'a823c204-c249-43f0-b150-e12b686122ea', 0, 0, 0, 1, 21900000, 21900000, NULL, NULL, '2024-05-18 18:03:52.6622+00', 'user@123', NULL, NULL);
INSERT INTO public."Products" ("Id", "UserId", "Name", "Description", "CategoryId", "Sold", "Rating", "TotalReviews", "Condition", "MinPrice", "MaxPrice", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', 'dbfef7a2-bb00-43e8-b112-b35736fe4d9d', 'Chuột không dây Bluetooth Logitech M550 Signature - SmartWheel, giảm ồn, 4000DPI, Đa thiết bị', 'ádasdbaskfbkfbadslkoahuasiodkjlam,s.đá', '7d5fcb47-5c7b-4519-8d39-22086e194fb0', 1, 5, 1, 0, 579000, 579000, NULL, NULL, '2024-05-19 05:22:21.457076+00', 'user1@123', '2024-05-19 13:30:44.91301+00', 'guest');


--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Users" ("Id", "Name", "AverageRating", "AvatarUrl", "CoverUrl", "ProductSold", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('d60dff58-0eea-4c64-a5e3-0b1d32cded75', 'User', 0, NULL, NULL, 0, NULL, NULL, '2024-05-18 17:47:48.420587+00', 'guest', NULL, NULL);
INSERT INTO public."Users" ("Id", "Name", "AverageRating", "AvatarUrl", "CoverUrl", "ProductSold", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('dbfef7a2-bb00-43e8-b112-b35736fe4d9d', 'LOGITECH OFFICIAL SHOP', 0, NULL, NULL, 0, NULL, NULL, '2024-05-19 04:14:48.661347+00', 'guest', NULL, NULL);
INSERT INTO public."Users" ("Id", "Name", "AverageRating", "AvatarUrl", "CoverUrl", "ProductSold", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('356e6f1c-a32b-4a37-9cfc-577826fba924', 'Nam', 0, NULL, NULL, 0, NULL, NULL, '2024-05-19 13:20:37.900721+00', 'guest', NULL, NULL);


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231203091515_InitializeSalesTables', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231207162800_CreateCartTables', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231209142845_ChangeProductIdToProductTypeIdInCartsTable', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231226101516_ApplyUniqueFilters', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20240103112948_RemoveTotalPriceFromUsersTable', '7.0.10');


--
-- Name: Cart PK_Cart; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Cart"
    ADD CONSTRAINT "PK_Cart" PRIMARY KEY ("Id");


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
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_Cart_ProductTypeId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Cart_ProductTypeId" ON public."Cart" USING btree ("ProductTypeId");


--
-- Name: IX_Cart_UserId_ProductTypeId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_Cart_UserId_ProductTypeId" ON public."Cart" USING btree ("UserId", "ProductTypeId") WHERE ("DeletedAt" IS NULL);


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
-- Name: IX_Products_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Products_UserId" ON public."Products" USING btree ("UserId");


--
-- Name: Cart FK_Cart_ProductTypes_ProductTypeId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Cart"
    ADD CONSTRAINT "FK_Cart_ProductTypes_ProductTypeId" FOREIGN KEY ("ProductTypeId") REFERENCES public."ProductTypes"("Id") ON DELETE CASCADE;


--
-- Name: Cart FK_Cart_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Cart"
    ADD CONSTRAINT "FK_Cart_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


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
-- Name: Products FK_Products_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "FK_Products_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

