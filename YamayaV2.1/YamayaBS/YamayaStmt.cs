﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Yamaya
{
    class YamayaStmt
    {
        //Internal Test Only
        //internal const string GET_AREA_DATA = "SELECT AREACODE, PREFECTUREJAPANESE, PREFECTUREENGLISH, AREAJAPANESE, AREAENGLISH, DISTRICTJAPANESE, DISTRICTENGLISH, 0 AS REC_DELETED FROM DM_AREA_MAPPING_T";
        //internal const string GET_CATEGORY_DATA = "SELECT CATEGORYCODE, DESCRIPTIONENGLISH, DESCRIPTIONJAPANESE, 0 AS REC_DELETED FROM DM_ITEM_CAT_CODE_T";
        //internal const string GET_STORE_DATA = "SELECT STORESIZE, STORESIZEDESCJAPANESE, STORESIZEDESCENGLISH, 0 AS REC_DELETED FROM DM_STORE_SIZE_MAPPING_T";
        //internal const string GET_ITEM_DATA = "SELECT ITEMCODE, ITEMBRAND, ITEMSUBBRAND, ITEMWINETYPE, ITEMWINECOLOR, COUNTRYOFORIGIN, ITEMCATEGORY, ITEMAUTHENTICITY, 0 AS REC_DELETED FROM DM_ITEM_MAPPING_T";
        //internal const string GET_ITEMDESC_DATA = "SELECT ITEMCATEGORY, ITEMSEQUENCE, ITEMCATEGORYDESCJAPANESE, ITEMCATEGORYDESCENGLISH, 0 AS REC_DELETED FROM DM_ITEM_DESC_MAPPING_T";

        //internal const string INS_AREA_DATA = "INSERT INTO DM_AREA_MAPPING_T (AREACODE, PREFECTUREJAPANESE, PREFECTUREENGLISH, AREAJAPANESE, AREAENGLISH, DISTRICTJAPANESE, DISTRICTENGLISH) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
        //internal const string INS_CATEGORY_DATA = "INSERT INTO DM_ITEM_CAT_CODE_T (CATEGORYCODE, DESCRIPTIONENGLISH, DESCRIPTIONJAPANESE) VALUES ('{0}', '{1}', '{2}')";
        //internal const string INS_STORE_DATA = "INSERT INTO DM_STORE_SIZE_MAPPING_T (STORESIZE, STORESIZEDESCJAPANESE, STORESIZEDESCENGLISH) VALUES ('{0}', '{1}', '{2}')";
        //internal const string INS_ITEM_DATA = "INSERT INTO DM_ITEM_MAPPING_T (ITEMCODE, ITEMBRAND, ITEMSUBBRAND, ITEMWINETYPE, ITEMWINECOLOR, COUNTRYOFORIGIN, ITEMCATEGORY, ITEMAUTHENTICITY) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";
        //internal const string INS_ITEMDESC_DATA = "INSERT INTO DM_ITEM_DESC_MAPPING_T (ITEMCATEGORY, ITEMSEQUENCE, ITEMCATEGORYDESCJAPANESE, ITEMCATEGORYDESCENGLISH) VALUES ('{0}', '{1}', '{2}', '{3}')";

        //internal const string UPD_AREA_DATA = "UPDATE DM_AREA_MAPPING_T SET AREACODE = '{0}', PREFECTUREJAPANESE = '{1}', PREFECTUREENGLISH = '{2}', AREAJAPANESE = '{3}', AREAENGLISH = '{4}', DISTRICTJAPANESE = '{5}', DISTRICTENGLISH = '{6}' WHERE AREACODE = '{0}' ";
        //internal const string UPD_CATEGROY_DATA = "UPDATE DM_ITEM_CAT_CODE_T SET CATEGORYCODE = '{0}', DESCRIPTIONENGLISH = '{1}', DESCRIPTIONJAPANESE = '{2}' WHERE CATEGORYCODE = '{0}'";
        //internal const string UPD_STORE_DATA = "UPDATE DM_STORE_SIZE_MAPPING_T SET STORESIZE = '{0}', STORESIZEDESCJAPANESE = '{1}', STORESIZEDESCENGLISH = '{2}' WHERE STORESIZE = '{0}'";
        //internal const string UPD_ITEM_DATA = "UPDATE DM_ITEM_MAPPING_T SET ITEMCODE = '{0}', ITEMBRAND = '{1}', ITEMSUBBRAND = '{2}', ITEMWINETYPE = '{3}', ITEMWINECOLOR = '{4}', COUNTRYOFORIGIN = '{5}', ITEMCATEGORY = '{6}', ITEMAUTHENTICITY = '{7}' WHERE ITEMCODE = '{0}'";
        //internal const string UPD_ITEMDESC_DATA = "UPDATE DM_ITEM_DESC_MAPPING_T SET ITEMCATEGORY = '{0}', ITEMSEQUENCE = '{1}', ITEMCATEGORYDESCJAPANESE = '{2}', ITEMCATEGORYDESCENGLISH = '{3}' WHERE ITEMCATEGORY = '{0}'";

        //internal const string DEL_AREA_DATA = "DELETE FROM DM_AREA_MAPPING_T WHERE AREACODE = '{0}' ";
        //internal const string DEL_CATEGORY_DATA = "DELETE FROM DM_ITEM_CAT_CODE_T WHERE CATEGORYCODE = '{0}' ";
        //internal const string DEL_STORE_DATA = "DELETE FROM DM_STORE_SIZE_MAPPING_T WHERE STORESIZE = '{0}' ";
        //internal const string DEL_ITEM_DATA = "DELETE FROM DM_ITEM_MAPPING_T WHERE ITEMCODE = '{0}' ";
        //internal const string DEL_ITEMDESC_DATA = "DELETE FROM DM_ITEM_DESC_MAPPING_T WHERE ITEMCATEGORY = '{0}' ";




        //internal const string UPD_STORE_SIZE_MAPPING = "UPDATE (SELECT ST.STORESIZEDESCRIPTION1, ST.STORESIZEDESCRIPTION2, SZ.STORESIZEDESCJAPANESE, SZ.STORESIZEDESCENGLISH " +
        //                                               "FROM DM_STORE_T ST, DM_STORE_SIZE_MAPPING_T SZ WHERE ST.STORESIZE = SZ.STORESIZE) T "+
        //                                               "SET STORESIZEDESCRIPTION1=STORESIZEDESCJAPANESE, STORESIZEDESCRIPTION2=STORESIZEDESCENGLISH";



        //internal const string UPD_AREA_MAPPING = "UPDATE (SELECT ST.PREFECTUREDESCRIPTION1, AR.PREFECTUREJAPANESE, ST.PREFECTUREDESCRIPTION2, AR.PREFECTUREENGLISH, " +
        //                                         "ST.AREADESCRIPTION1, AR.AREAJAPANESE, ST.AREADESCRIPTION2, AR.AREAENGLISH, ST.DISTRICTDESCRIPTION1, AR.DISTRICTJAPANESE, " +
        //                                         "ST.DISTRICTDESCRIPTION2, AR.DISTRICTENGLISH FROM DM_STORE_T ST, DM_AREA_MAPPING_T AR WHERE ST.PREFECTURECODE = AR.AREACODE) T " + 
        //                                         "SET PREFECTUREDESCRIPTION1=PREFECTUREJAPANESE, PREFECTUREDESCRIPTION2=PREFECTUREENGLISH, AREADESCRIPTION1=AREAJAPANESE, AREADESCRIPTION2=AREAENGLISH, " +
        //                                         "DISTRICTDESCRIPTION1=DISTRICTJAPANESE, DISTRICTDESCRIPTION2=DISTRICTENGLISH";




        //internal const string UPD_ITEM_CAT_MAPPING1 = "UPDATE (SELECT I.ITEMCATEGORY01DESCRIPTION1, I.ITEMCATEGORY01DESCRIPTION2, C.DESCRIPTIONENGLISH, C.DESCRIPTIONJAPANESE " +
        //                                              "FROM DM_ITEM_T I, DM_ITEM_CAT_CODE_T C WHERE I.ITEMCATEGORY01 = C.CATEGORYCODE) T " +
        //                                              "SET ITEMCATEGORY01DESCRIPTION1=DESCRIPTIONJAPANESE, ITEMCATEGORY01DESCRIPTION2=DESCRIPTIONENGLISH";

        //internal const string UPD_ITEM_CAT_MAPPING2 = "UPDATE (SELECT I.ITEMCATEGORY02DESCRIPTION1, I.ITEMCATEGORY02DESCRIPTION2, C.DESCRIPTIONENGLISH, C.DESCRIPTIONJAPANESE " +
        //                                              "FROM DM_ITEM_T I, DM_ITEM_CAT_CODE_T C WHERE I.ITEMCATEGORY02 = C.CATEGORYCODE) T " +
        //                                              "SET ITEMCATEGORY02DESCRIPTION1=DESCRIPTIONJAPANESE, ITEMCATEGORY02DESCRIPTION2=DESCRIPTIONENGLISH";

        //internal const string UPD_ITEM_CAT_MAPPING3 = "UPDATE (SELECT I.ITEMCATEGORY03DESCRIPTION1, I.ITEMCATEGORY03DESCRIPTION2, C.DESCRIPTIONENGLISH, C.DESCRIPTIONJAPANESE " +
        //                                              "FROM DM_ITEM_T I, DM_ITEM_CAT_CODE_T C WHERE I.ITEMCATEGORY03 = C.CATEGORYCODE) T " +
        //                                              "SET ITEMCATEGORY03DESCRIPTION1=DESCRIPTIONJAPANESE, ITEMCATEGORY03DESCRIPTION2=DESCRIPTIONENGLISH";



        //internal const string UPD_ITEM_MAPPING = "UPDATE (SELECT I.BRAND, I.BRANDSAL, I.BRANDMKT, I.ITEMGROUP, I.IMPORTER, I.COMPETITORGROUPSAL, I.COMPETITORGROUPMKT, " +
        //                                         "M.ITEMBRAND, M.ITEMSUBBRAND, M.ITEMWINETYPE, ITEMWINECOLOR, M.COUNTRYOFORIGIN, M.ITEMCATEGORY, M.ITEMAUTHENTICITY " +
        //                                         "FROM DM_ITEM_T I, DM_ITEM_MAPPING_T M WHERE I.ITEMCODE = M.ITEMCODE) T " +
        //                                         "SET BRAND=ITEMBRAND, BRANDSAL=ITEMSUBBRAND, BRANDMKT=ITEMWINETYPE, ITEMGROUP=ITEMWINECOLOR, IMPORTER=COUNTRYOFORIGIN, " +
        //                                         "COMPETITORGROUPSAL=ITEMCATEGORY, COMPETITORGROUPMKT=ITEMAUTHENTICITY";



        //internal const string UPD_ITEM_DESC_MAPPING1 = "UPDATE DM_ITEM_T SET BRANDDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING_T WHERE BRAND = ITEMCATEGORY AND ROWNUM=1), " +
        //                                                "BRANDDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING_T WHERE BRAND = ITEMCATEGORY AND ROWNUM=1) " +
        //                                                "WHERE BRAND IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING2 = "UPDATE DM_ITEM_T SET BRANDSALDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING_T WHERE BRANDSAL = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "BRANDSALDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING_T WHERE BRANDSAL = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE BRANDSAL IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING3 = "UPDATE DM_ITEM_T SET BRANDMKTDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING_T WHERE BRANDMKT = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "BRANDMKTDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING_T WHERE BRANDMKT = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE BRANDMKT IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING4 = "UPDATE DM_ITEM_T SET ITEMGROUPDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING_T WHERE ITEMGROUP = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "ITEMGROUPDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING_T WHERE ITEMGROUP = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE ITEMGROUP IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING5 = "UPDATE DM_ITEM_T SET IMPORTERDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING_T WHERE IMPORTER = ITEMCATEGORY AND ROWNUM=1), " +
        //                                                "IMPORTERDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING_T WHERE IMPORTER = ITEMCATEGORY AND ROWNUM=1) " +
        //                                                "WHERE IMPORTER IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING6 = "UPDATE DM_ITEM_T SET COMPETITORGROUPSALDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING_T WHERE COMPETITORGROUPSAL = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "COMPETITORGROUPSALDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING_T WHERE COMPETITORGROUPSAL = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE COMPETITORGROUPSAL IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING7 = "UPDATE DM_ITEM_T SET COMPETITORGROUPMKTDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING_T WHERE COMPETITORGROUPMKT = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "COMPETITORGROUPMKTDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING_T WHERE COMPETITORGROUPMKT = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE COMPETITORGROUPMKT IS NOT NULL";


        //Release
        //internal const string GET_AREA_DATA = "SELECT AREACODE, PREFECTUREJAPANESE, PREFECTUREENGLISH, AREAJAPANESE, AREAENGLISH, DISTRICTJAPANESE, DISTRICTENGLISH, 0 AS REC_DELETED FROM JPMKT.DM_AREA_MAPPING_T";
        //internal const string GET_CATEGORY_DATA = "SELECT CATEGORYCODE, DESCRIPTIONENGLISH, DESCRIPTIONJAPANESE, 0 AS REC_DELETED FROM JPMKT.DM_ITEM_CAT_CODE_T";
        //internal const string GET_STORE_DATA = "SELECT STORESIZE, STORESIZEDESCJAPANESE, STORESIZEDESCENGLISH, 0 AS REC_DELETED FROM JPMKT.DM_STORE_SIZE_MAPPING_T";
        //internal const string GET_ITEM_DATA = "SELECT ITEMCODE, ITEMBRAND, ITEMSUBBRAND, ITEMWINETYPE, ITEMWINECOLOR, COUNTRYOFORIGIN, ITEMCATEGORY, ITEMAUTHENTICITY, 0 AS REC_DELETED FROM JPMKT.DM_ITEM_MAPPING_T";
        //internal const string GET_ITEMDESC_DATA = "SELECT ITEMCATEGORY, ITEMSEQUENCE, ITEMCATEGORYDESCJAPANESE, ITEMCATEGORYDESCENGLISH, 0 AS REC_DELETED FROM JPMKT.DM_ITEM_DESC_MAPPING_T";

        //internal const string INS_AREA_DATA = "INSERT INTO JPMKT.DM_AREA_MAPPING_T (AREACODE, PREFECTUREJAPANESE, PREFECTUREENGLISH, AREAJAPANESE, AREAENGLISH, DISTRICTJAPANESE, DISTRICTENGLISH) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
        //internal const string INS_CATEGORY_DATA = "INSERT INTO JPMKT.DM_ITEM_CAT_CODE_T (CATEGORYCODE, DESCRIPTIONENGLISH, DESCRIPTIONJAPANESE) VALUES ('{0}', '{1}', '{2}')";
        //internal const string INS_STORE_DATA = "INSERT INTO JPMKT.DM_STORE_SIZE_MAPPING_T (STORESIZE, STORESIZEDESCJAPANESE, STORESIZEDESCENGLISH) VALUES ('{0}', '{1}', '{2}')";
        //internal const string INS_ITEM_DATA = "INSERT INTO JPMKT.DM_ITEM_MAPPING_T (ITEMCODE, ITEMBRAND, ITEMSUBBRAND, ITEMWINETYPE, ITEMWINECOLOR, COUNTRYOFORIGIN, ITEMCATEGORY, ITEMAUTHENTICITY) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";
        //internal const string INS_ITEMDESC_DATA = "INSERT INTO JPMKT.DM_ITEM_DESC_MAPPING_T (ITEMCATEGORY, ITEMSEQUENCE, ITEMCATEGORYDESCJAPANESE, ITEMCATEGORYDESCENGLISH) VALUES ('{0}', '{1}', '{2}', '{3}')";

        //internal const string UPD_AREA_DATA = "UPDATE JPMKT.DM_AREA_MAPPING_T SET AREACODE = '{0}', PREFECTUREJAPANESE = '{1}', PREFECTUREENGLISH = '{2}', AREAJAPANESE = '{3}', AREAENGLISH = '{4}', DISTRICTJAPANESE = '{5}', DISTRICTENGLISH = '{6}' WHERE AREACODE = '{0}' ";
        //internal const string UPD_CATEGROY_DATA = "UPDATE JPMKT.DM_ITEM_CAT_CODE_T SET CATEGORYCODE = '{0}', DESCRIPTIONENGLISH = '{1}', DESCRIPTIONJAPANESE = '{2}' WHERE CATEGORYCODE = '{0}'";
        //internal const string UPD_STORE_DATA = "UPDATE JPMKT.DM_STORE_SIZE_MAPPING_T SET STORESIZE = '{0}', STORESIZEDESCJAPANESE = '{1}', STORESIZEDESCENGLISH = '{2}' WHERE STORESIZE = '{0}'";
        //internal const string UPD_ITEM_DATA = "UPDATE JPMKT.DM_ITEM_MAPPING_T SET ITEMCODE = '{0}', ITEMBRAND = '{1}', ITEMSUBBRAND = '{2}', ITEMWINETYPE = '{3}', ITEMWINECOLOR = '{4}', COUNTRYOFORIGIN = '{5}', ITEMCATEGORY = '{6}', ITEMAUTHENTICITY = '{7}' WHERE ITEMCODE = '{0}'";
        //internal const string UPD_ITEMDESC_DATA = "UPDATE JPMKT.DM_ITEM_DESC_MAPPING_T SET ITEMCATEGORY = '{0}', ITEMSEQUENCE = '{1}', ITEMCATEGORYDESCJAPANESE = '{2}', ITEMCATEGORYDESCENGLISH = '{3}' WHERE ITEMCATEGORY = '{0}'";

        //internal const string DEL_AREA_DATA = "DELETE FROM JPMKT.DM_AREA_MAPPING_T WHERE AREACODE = '{0}' ";
        //internal const string DEL_CATEGORY_DATA = "DELETE FROM JPMKT.DM_ITEM_CAT_CODE_T WHERE CATEGORYCODE = '{0}' ";
        //internal const string DEL_STORE_DATA = "DELETE FROM JPMKT.DM_STORE_SIZE_MAPPING_T WHERE STORESIZE = '{0}' ";
        //internal const string DEL_ITEM_DATA = "DELETE FROM JPMKT.DM_ITEM_MAPPING_T WHERE ITEMCODE = '{0}' ";
        //internal const string DEL_ITEMDESC_DATA = "DELETE FROM JPMKT.DM_ITEM_DESC_MAPPING_T WHERE ITEMCATEGORY = '{0}' ";




        //internal const string UPD_STORE_SIZE_MAPPING = "UPDATE (SELECT ST.STORESIZEDESCRIPTION1, ST.STORESIZEDESCRIPTION2, SZ.STORESIZEDESCJAPANESE, SZ.STORESIZEDESCENGLISH " +
        //                                               "FROM DM_STORE ST, DM_STORE_SIZE_MAPPING SZ WHERE ST.STORESIZE = SZ.STORESIZE) T " +
        //                                               "SET STORESIZEDESCRIPTION1=STORESIZEDESCJAPANESE, STORESIZEDESCRIPTION2=STORESIZEDESCENGLISH";

        //internal const string UPD_AREA_MAPPING = "UPDATE (SELECT ST.PREFECTUREDESCRIPTION1, AR.PREFECTUREJAPANESE, ST.PREFECTUREDESCRIPTION2, AR.PREFECTUREENGLISH, " +
        //                                         "ST.AREADESCRIPTION1, AR.AREAJAPANESE, ST.AREADESCRIPTION2, AR.AREAENGLISH, ST.DISTRICTDESCRIPTION1, AR.DISTRICTJAPANESE, " +
        //                                         "ST.DISTRICTDESCRIPTION2, AR.DISTRICTENGLISH FROM DM_STORE ST, DM_AREA_MAPPING AR WHERE ST.PREFECTURECODE = AR.AREACODE) T " +
        //                                         "SET PREFECTUREDESCRIPTION1=PREFECTUREJAPANESE, PREFECTUREDESCRIPTION2=PREFECTUREENGLISH, AREADESCRIPTION1=AREAJAPANESE, AREADESCRIPTION2=AREAENGLISH, " +
        //                                         "DISTRICTDESCRIPTION1=DISTRICTJAPANESE, DISTRICTDESCRIPTION2=DISTRICTENGLISH";




        //internal const string UPD_ITEM_CAT_MAPPING1 = "UPDATE (SELECT I.ITEMCATEGORY01DESCRIPTION1, I.ITEMCATEGORY01DESCRIPTION2, C.DESCRIPTIONENGLISH, C.DESCRIPTIONJAPANESE " +
        //                                              "FROM DM_ITEM I, DM_ITEM_CAT_CODE C WHERE I.ITEMCATEGORY01 = C.CATEGORYCODE) T " +
        //                                              "SET ITEMCATEGORY01DESCRIPTION1=DESCRIPTIONJAPANESE, ITEMCATEGORY01DESCRIPTION2=DESCRIPTIONENGLISH";

        //internal const string UPD_ITEM_CAT_MAPPING2 = "UPDATE (SELECT I.ITEMCATEGORY02DESCRIPTION1, I.ITEMCATEGORY02DESCRIPTION2, C.DESCRIPTIONENGLISH, C.DESCRIPTIONJAPANESE " +
        //                                              "FROM DM_ITEM I, DM_ITEM_CAT_CODE C WHERE I.ITEMCATEGORY02 = C.CATEGORYCODE) T " +
        //                                              "SET ITEMCATEGORY02DESCRIPTION1=DESCRIPTIONJAPANESE, ITEMCATEGORY02DESCRIPTION2=DESCRIPTIONENGLISH";

        //internal const string UPD_ITEM_CAT_MAPPING3 = "UPDATE (SELECT I.ITEMCATEGORY03DESCRIPTION1, I.ITEMCATEGORY03DESCRIPTION2, C.DESCRIPTIONENGLISH, C.DESCRIPTIONJAPANESE " +
        //                                              "FROM DM_ITEM I, DM_ITEM_CAT_CODE C WHERE I.ITEMCATEGORY03 = C.CATEGORYCODE) T " +
        //                                              "SET ITEMCATEGORY03DESCRIPTION1=DESCRIPTIONJAPANESE, ITEMCATEGORY03DESCRIPTION2=DESCRIPTIONENGLISH";



        //internal const string UPD_ITEM_MAPPING = "UPDATE (SELECT I.BRAND, I.BRANDSAL, I.BRANDMKT, I.ITEMGROUP, I.IMPORTER, I.COMPETITORGROUPSAL, I.COMPETITORGROUPMKT, " +
        //                                         "M.ITEMBRAND, M.ITEMSUBBRAND, M.ITEMWINETYPE, ITEMWINECOLOR, M.COUNTRYOFORIGIN, M.ITEMCATEGORY, M.ITEMAUTHENTICITY " +
        //                                         "FROM DM_ITEM I, DM_ITEM_MAPPING M WHERE I.ITEMCODE = M.ITEMCODE) T " +
        //                                         "SET BRAND=ITEMBRAND, BRANDSAL=ITEMSUBBRAND, BRANDMKT=ITEMWINETYPE, ITEMGROUP=ITEMWINECOLOR, IMPORTER=COUNTRYOFORIGIN, " +
        //                                         "COMPETITORGROUPSAL=ITEMCATEGORY, COMPETITORGROUPMKT=ITEMAUTHENTICITY";



        //internal const string UPD_ITEM_DESC_MAPPING1 = "UPDATE DM_ITEM SET BRANDDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING WHERE BRAND = ITEMCATEGORY AND ROWNUM=1), " +
        //                                                "BRANDDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING WHERE BRAND = ITEMCATEGORY AND ROWNUM=1) " +
        //                                                "WHERE BRAND IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING2 = "UPDATE DM_ITEM SET BRANDSALDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING WHERE BRANDSAL = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "BRANDSALDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING WHERE BRANDSAL = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE BRANDSAL IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING3 = "UPDATE DM_ITEM SET BRANDMKTDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING WHERE BRANDMKT = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "BRANDMKTDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING WHERE BRANDMKT = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE BRANDMKT IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING4 = "UPDATE DM_ITEM SET ITEMGROUPDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING WHERE ITEMGROUP = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "ITEMGROUPDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING WHERE ITEMGROUP = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE ITEMGROUP IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING5 = "UPDATE DM_ITEM SET IMPORTERDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING WHERE IMPORTER = ITEMCATEGORY AND ROWNUM=1), " +
        //                                                "IMPORTERDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING WHERE IMPORTER = ITEMCATEGORY AND ROWNUM=1) " +
        //                                                "WHERE IMPORTER IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING6 = "UPDATE DM_ITEM SET COMPETITORGROUPSALDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING WHERE COMPETITORGROUPSAL = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "COMPETITORGROUPSALDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING WHERE COMPETITORGROUPSAL = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE COMPETITORGROUPSAL IS NOT NULL";

        //internal const string UPD_ITEM_DESC_MAPPING7 = "UPDATE DM_ITEM SET COMPETITORGROUPMKTDESCRIPTION1=(SELECT ITEMCATEGORYDESCJAPANESE FROM DM_ITEM_DESC_MAPPING WHERE COMPETITORGROUPMKT = ITEMCATEGORY AND ROWNUM=1), " +
        //                                               "COMPETITORGROUPMKTDESCRIPTION2=(SELECT ITEMCATEGORYDESCENGLISH FROM DM_ITEM_DESC_MAPPING WHERE COMPETITORGROUPMKT = ITEMCATEGORY AND ROWNUM=1) " +
        //                                               "WHERE COMPETITORGROUPMKT IS NOT NULL";

    }
}
