CREATE TABLE HT_BodyTemperature (
    ID VARCHAR(50) NOT NULL,
    ArchivesCode VARCHAR(50) NOT NULL,
    MacID VARCHAR(50) NOT NULL,
    Manufacture VARCHAR(50) NOT NULL,
    MeasureDate DATETIME NOT NULL,
    BodyTemperature DECIMAL(18,2) NOT NULL,
    DataSource VARCHAR(50) NOT NULL,
    Remark VARCHAR(200) NULL,
    PRIMARY KEY (ID)
);