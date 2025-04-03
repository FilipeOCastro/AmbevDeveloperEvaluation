CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Users" (
    "Id" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "Username" character varying(50) NOT NULL,
    "Password" character varying(100) NOT NULL,
    "Phone" character varying(20) NOT NULL,
    "Email" character varying(100) NOT NULL,
    "Status" character varying(20) NOT NULL,
    "Role" character varying(20) NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20241014011203_InitialMigrations', '8.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE "Users" ADD "CreatedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "Users" ADD "UpdatedAt" timestamp with time zone;

CREATE TABLE "Cart" (
    "Id" uuid NOT NULL,
    "Number" character varying(50) NOT NULL,
    "CreateDate" timestamp with time zone NOT NULL,
    "UserId" uuid NOT NULL,
    "TotalAmount" numeric(18,2) NOT NULL,
    "BranchName" character varying(100) NOT NULL,
    "IsCancelled" boolean NOT NULL,
    CONSTRAINT "PK_Cart" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Cart_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "Product" (
    "Id" uuid NOT NULL,
    "Title" character varying(100) NOT NULL,
    "Price" numeric(18,2) NOT NULL,
    "Description" character varying(500) NOT NULL,
    "Category" character varying(100) NOT NULL,
    "Image" character varying(500) NOT NULL,
    "Rate" numeric NOT NULL,
    "Count" integer NOT NULL,
    CONSTRAINT "PK_Product" PRIMARY KEY ("Id")
);

CREATE TABLE "CartItem" (
    "Id" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    "Quantity" integer NOT NULL,
    "UnitPrice" numeric(18,2) NOT NULL,
    "Discount" numeric(18,2) NOT NULL,
    "TotalPrice" numeric(18,2) NOT NULL,
    "CartId" uuid NOT NULL,
    CONSTRAINT "PK_CartItem" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_CartItem_Cart_CartId" FOREIGN KEY ("CartId") REFERENCES "Cart" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_CartItem_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Product" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_Cart_UserId" ON "Cart" ("UserId");

CREATE INDEX "IX_CartItem_CartId" ON "CartItem" ("CartId");

CREATE INDEX "IX_CartItem_ProductId" ON "CartItem" ("ProductId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250403182537_AddTables', '8.0.10');

COMMIT;