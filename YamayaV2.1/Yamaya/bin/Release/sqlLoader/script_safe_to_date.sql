CREATE OR REPLACE
FUNCTION SAFE_TO_DATE(p_str IN VARCHAR2, p_format IN VARCHAR2) RETURN DATE
IS
BEGIN
  RETURN TO_DATE( p_str, p_format );
EXCEPTION
  WHEN OTHERS THEN
  RETURN NULL;
END;
/