drop table "__EFMigrationsHistory" cascade;

drop table "OrderItems" cascade;

drop table "LikedReview" cascade;

drop table "Reviews" cascade;

drop table "ProductTypes" cascade;

drop table "Products" cascade;

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
-- Name: LikedReview; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."LikedReview" (
    "Id" uuid NOT NULL,
    "ReviewId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
);


ALTER TABLE public."LikedReview" OWNER TO postgres;

--
-- Name: OrderItems; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."OrderItems" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "ProductTypeId" uuid NOT NULL,
    "Quantity" integer NOT NULL,
    "TotalPrice" double precision NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
);


ALTER TABLE public."OrderItems" OWNER TO postgres;

--
-- Name: ProductTypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ProductTypes" (
    "Id" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "Price" double precision NOT NULL,
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
    "ImageUrl" text NOT NULL,
    "Name" character varying(256) NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
);


ALTER TABLE public."Products" OWNER TO postgres;

--
-- Name: Reviews; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Reviews" (
    "Id" uuid NOT NULL,
    "Content" text,
    "ProductTypeId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Rating" integer NOT NULL,
    "ParentId" uuid,
    "Likes" integer NOT NULL,
    "DeletedAt" timestamp with time zone,
    "DeletedBy" text,
    "CreatedAt" timestamp with time zone NOT NULL,
    "CreatedBy" text NOT NULL,
    "UpdatedAt" timestamp with time zone,
    "UpdatedBy" text
);


ALTER TABLE public."Reviews" OWNER TO postgres;

--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "Name" character varying(320) NOT NULL,
    "AvatarUrl" text,
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
-- Data for Name: LikedReview; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: OrderItems; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."OrderItems" ("Id", "UserId", "ProductTypeId", "Quantity", "TotalPrice", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('2027531f-6a95-458c-9e63-9012de17e981', '356e6f1c-a32b-4a37-9cfc-577826fba924', '9652cb3b-40bf-4707-a949-bd12185ad428', 1, 579000, NULL, NULL, '2024-05-19 13:30:44.755078+00', 'user2@123', NULL, NULL);


--
-- Data for Name: ProductTypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Price", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('b6148f5b-3e5c-4e86-afef-b1b710d3ea6f', '9f3af889-e4f4-4783-b656-2ae59bdd0ea8', 'Đen', 15750000, NULL, NULL, '2024-05-18 18:00:03.851977+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Price", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('2bfea01b-3abe-4cdb-b10a-6cbd561e1894', 'a4f2b029-81ee-401b-a94e-cf1395460eab', '𝐌𝐢𝐝𝐧𝐢𝐠𝐡𝐭', 21900000, NULL, NULL, '2024-05-18 18:03:52.662206+00', 'user@123', NULL, NULL);
INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Price", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('54ea6cec-ee96-4895-88e6-2b6bce3aad3c', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', 'M550 Size L (Đen)', 579000, NULL, NULL, '2024-05-19 05:22:21.45708+00', 'user1@123', NULL, NULL);
INSERT INTO public."ProductTypes" ("Id", "ProductId", "Name", "Price", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('9652cb3b-40bf-4707-a949-bd12185ad428', '4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', 'M550 Đen (M)', 579000, NULL, NULL, '2024-05-19 05:22:21.45708+00', 'user1@123', NULL, NULL);


--
-- Data for Name: Products; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Products" ("Id", "UserId", "ImageUrl", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('9f3af889-e4f4-4783-b656-2ae59bdd0ea8', 'd60dff58-0eea-4c64-a5e3-0b1d32cded75', 'https://cdn.chotot.com/AXbhSceSAXuLIeewlNYWdblst_eP0OHiEpf0DwJQpp4/preset:view/plain/d2ed968d68398c44a9b2ad23f0fcd587-2868277240205693416.jpg', 'Máy Game STEAM DECK OLED 512GB LƯỚT FULLBOX xịnnn✨', NULL, NULL, '2024-05-18 18:00:03.85191+00', 'user@123', NULL, NULL);
INSERT INTO public."Products" ("Id", "UserId", "ImageUrl", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('a4f2b029-81ee-401b-a94e-cf1395460eab', 'd60dff58-0eea-4c64-a5e3-0b1d32cded75', 'https://cdn.chotot.com/G5-1-hHbyc6qeoZS7nLUcNycqPyqyPaf6XsjK1yAMkE/preset:view/plain/db6dc97ec3724e9337ce3b9bba881c27-2871787427681450210.jpg', '𝐌𝐚𝐜𝐛𝐨𝐨𝐤 𝐀𝐢𝐫 𝟏𝟑 𝐌𝐢𝐝𝐧𝐢𝐠𝐡𝐭 𝟐𝟎𝟐𝟑 𝐌𝟐/𝟖/𝟐𝟓𝟔 𝐎𝐩𝐞𝐧𝐛𝐨𝐱', NULL, NULL, '2024-05-18 18:03:52.6622+00', 'user@123', NULL, NULL);
INSERT INTO public."Products" ("Id", "UserId", "ImageUrl", "Name", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('4fdae4dc-4130-4cf9-9f92-1e6d02e1ff3e', 'dbfef7a2-bb00-43e8-b112-b35736fe4d9d', 'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmcn2dy8tc674e', 'Chuột không dây Bluetooth Logitech M550 Signature - SmartWheel, giảm ồn, 4000DPI, Đa thiết bị', NULL, NULL, '2024-05-19 05:22:21.457076+00', 'user1@123', NULL, NULL);


--
-- Data for Name: Reviews; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Reviews" ("Id", "Content", "ProductTypeId", "UserId", "Rating", "ParentId", "Likes", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('174c8a8e-0747-49c9-bb1f-55c0c38d380b', 'Chuột kết nối cổng usb va cả bluetooth nên giá cung hơn 570k, áp kmai 7749 bước còn 490k, nên chốt deal, k biết pin xai dc 2nam như lời gthieu k', '9652cb3b-40bf-4707-a949-bd12185ad428', '356e6f1c-a32b-4a37-9cfc-577826fba924', 5, NULL, 0, NULL, NULL, '2024-05-19 13:31:56.774473+00', 'user2@123', NULL, NULL);


--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Users" ("Id", "Name", "AvatarUrl", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('d60dff58-0eea-4c64-a5e3-0b1d32cded75', 'User', NULL, NULL, NULL, '2024-05-18 17:47:48.420587+00', 'guest', NULL, NULL);
INSERT INTO public."Users" ("Id", "Name", "AvatarUrl", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('dbfef7a2-bb00-43e8-b112-b35736fe4d9d', 'LOGITECH OFFICIAL SHOP', NULL, NULL, NULL, '2024-05-19 04:14:48.661347+00', 'guest', NULL, NULL);
INSERT INTO public."Users" ("Id", "Name", "AvatarUrl", "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy") VALUES ('356e6f1c-a32b-4a37-9cfc-577826fba924', 'Nam', NULL, NULL, NULL, '2024-05-19 13:20:37.900721+00', 'guest', NULL, NULL);


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231230154413_InitializeReviewTables', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231231074250_CreateLikedReviewsTable', '7.0.10');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20240103172547_AddNameConstraintToProductsTable', '7.0.10');


--
-- Name: LikedReview PK_LikedReview; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."LikedReview"
    ADD CONSTRAINT "PK_LikedReview" PRIMARY KEY ("Id");


--
-- Name: OrderItems PK_OrderItems; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderItems"
    ADD CONSTRAINT "PK_OrderItems" PRIMARY KEY ("Id");


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
-- Name: Reviews PK_Reviews; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reviews"
    ADD CONSTRAINT "PK_Reviews" PRIMARY KEY ("Id");


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
-- Name: IX_LikedReview_ReviewId_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_LikedReview_ReviewId_UserId" ON public."LikedReview" USING btree ("ReviewId", "UserId") WHERE ("DeletedAt" IS NULL);


--
-- Name: IX_LikedReview_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_LikedReview_UserId" ON public."LikedReview" USING btree ("UserId");


--
-- Name: IX_OrderItems_ProductTypeId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_OrderItems_ProductTypeId" ON public."OrderItems" USING btree ("ProductTypeId");


--
-- Name: IX_OrderItems_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_OrderItems_UserId" ON public."OrderItems" USING btree ("UserId");


--
-- Name: IX_ProductTypes_ProductId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_ProductTypes_ProductId" ON public."ProductTypes" USING btree ("ProductId");


--
-- Name: IX_Products_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Products_UserId" ON public."Products" USING btree ("UserId");


--
-- Name: IX_Reviews_ParentId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Reviews_ParentId" ON public."Reviews" USING btree ("ParentId");


--
-- Name: IX_Reviews_ProductTypeId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Reviews_ProductTypeId" ON public."Reviews" USING btree ("ProductTypeId");


--
-- Name: IX_Reviews_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Reviews_UserId" ON public."Reviews" USING btree ("UserId");


--
-- Name: LikedReview FK_LikedReview_Reviews_ReviewId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."LikedReview"
    ADD CONSTRAINT "FK_LikedReview_Reviews_ReviewId" FOREIGN KEY ("ReviewId") REFERENCES public."Reviews"("Id") ON DELETE CASCADE;


--
-- Name: LikedReview FK_LikedReview_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."LikedReview"
    ADD CONSTRAINT "FK_LikedReview_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: OrderItems FK_OrderItems_ProductTypes_ProductTypeId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderItems"
    ADD CONSTRAINT "FK_OrderItems_ProductTypes_ProductTypeId" FOREIGN KEY ("ProductTypeId") REFERENCES public."ProductTypes"("Id") ON DELETE CASCADE;


--
-- Name: OrderItems FK_OrderItems_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OrderItems"
    ADD CONSTRAINT "FK_OrderItems_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: ProductTypes FK_ProductTypes_Products_ProductId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ProductTypes"
    ADD CONSTRAINT "FK_ProductTypes_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES public."Products"("Id") ON DELETE CASCADE;


--
-- Name: Products FK_Products_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "FK_Products_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- Name: Reviews FK_Reviews_ProductTypes_ProductTypeId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reviews"
    ADD CONSTRAINT "FK_Reviews_ProductTypes_ProductTypeId" FOREIGN KEY ("ProductTypeId") REFERENCES public."ProductTypes"("Id") ON DELETE CASCADE;


--
-- Name: Reviews FK_Reviews_Reviews_ParentId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reviews"
    ADD CONSTRAINT "FK_Reviews_Reviews_ParentId" FOREIGN KEY ("ParentId") REFERENCES public."Reviews"("Id");


--
-- Name: Reviews FK_Reviews_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Reviews"
    ADD CONSTRAINT "FK_Reviews_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

