<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" version="1.0" indent="yes"/>
  <xsl:template match="/">
    <xsl:processing-instruction name="magazine">
      <xsl:text>version="1.1" parser="SOAP"</xsl:text>
    </xsl:processing-instruction>
    <xsl:apply-templates/>
  </xsl:template>
  <xsl:template match="магазин">
    <magazine>
      <xsl:comment>
        <xsl:text>описание продуктов</xsl:text>
      </xsl:comment>
      <xsl:apply-templates/>
    </magazine>
  </xsl:template>
  <xsl:template match="товары">
    <products>
      <xsl:apply-templates/>
    </products>
  </xsl:template>
  <xsl:template match="товар">
    <product>
      <xsl:apply-templates/>
    </product>
  </xsl:template>
  <xsl:template match="полное_название">
    <fullname>
      <xsl:value-of select="."/>
    </fullname>
  </xsl:template>
  <xsl:template match="категория">
    <category>
      <name>
        <xsl:value-of select="название"/>
      </name>
    </category>
  </xsl:template>
  <xsl:template match="изготовитель">
    <producer>
      <name>
        <xsl:value-of select="название"/>
      </name>
    </producer>
  </xsl:template>
  <xsl:template match="количество">
    <quantity>
      <xsl:attribute name="measurement">
        <xsl:value-of select="@единица_измерения" />
      </xsl:attribute>
      <xsl:value-of select="."/>
    </quantity>
  </xsl:template>
  <xsl:template match="цена">
    <price>
      <xsl:attribute name="unit">
        <xsl:value-of select="@валюта"/>
      </xsl:attribute>
      <xsl:value-of select="."/>
    </price>
  </xsl:template>
  <xsl:template match="код | товар/название">
  </xsl:template>
</xsl:stylesheet>