<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="Item">
    <html>
      <head>
        <meta charset="utf-8"/>
        <title>Object</title>
        <style>
          body { min-width: 500px; font-family: Arial; text-align: justify; }
          .main { font-size: 16px; }
          .child { font-size: 12px; }
          .attribute { color: gray; }
          .attribute-link { text-decoration: none; }
          .syntax { background-color: #fafafa; border: 1px solid #e3e3e3; margin: 30px 0 30px 0; }
          .language { background-color: #f2f2f2; border-bottom: 1px solid #e3e3e3; padding: 5px 10px 5px 10px; }
          .data { padding: 10px; }
        </style>
      </head>
      <body>
        <h1>
          <xsl:value-of select="concat(@name, ' ', @type)"/>
        </h1>
        <div class="main">
          <span class="attribute">
            <xsl:value-of select ="concat(name(@namespace), ': ')"/>
          </span>
          <a class="attribute-link" href="#">
            <xsl:value-of select="@namespace"/>
          </a>
        </div>
        <p class="main">
          <xsl:value-of select ="Description"/>
        </p>
        <xsl:apply-templates select="Members/Constructors"/>
        <xsl:apply-templates select="Members/Methods"/>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="Members/Constructors">
    <h2>
      <xsl:value-of select ="name(.)"/>
    </h2>
    <xsl:for-each select="Constructor">
      <div>
        <span class="attribute">
          <xsl:value-of select ="concat(name(@access), ': ')"/>
        </span>
        <a class="attribute-link" href="#">
          <xsl:value-of select="@access"/>
        </a>
      </div>
      <xsl:for-each select="Declaration/Syntax">
        <div class="syntax">
          <div class="language">
            <xsl:value-of select ="@language"/>
          </div>
          <div class="data">
            <xsl:value-of select ="."/>
          </div>
        </div>
      </xsl:for-each>
    </xsl:for-each>
  </xsl:template>
  <xsl:template match="Members/Methods">
    <h2>
      <xsl:value-of select ="name(.)"/>
    </h2>
    <xsl:for-each select="Method">
      <h3>
        <xsl:value-of select ="@name"/>
      </h3>
      <div>
        <span class="attribute">
          <xsl:value-of select ="concat(name(@access), ': ')"/>
        </span>
        <a class="attribute-link" href="#">
          <xsl:value-of select="@access"/>
        </a>
      </div>
      <div>
        <span class="attribute">
          <xsl:value-of select ="concat(name(@returns), ': ')"/>
        </span>
        <a class="attribute-link" href="#">
          <xsl:value-of select="@returns"/>
        </a>
      </div>
      <xsl:for-each select="Declaration/Syntax">
        <div class="syntax">
          <div class="language">
            <xsl:value-of select ="@language"/>
          </div>
          <div class="data">
            <xsl:value-of select ="."/>
          </div>
        </div>
      </xsl:for-each>
      <p>
        <xsl:value-of select="Description"/>
      </p>
      <h4>
        <xsl:value-of select="name(Parameters)"/>
      </h4>
      <xsl:for-each select="Parameters/Parameter">
        <h5>
          <xsl:value-of select ="@name"/>
        </h5>
        <div class="child">
          <span class="attribute">
            <xsl:value-of select ="concat(name(@type), ': ')"/>
          </span>
          <a class="attribute-link" href="#">
            <xsl:value-of select="@type"/>
          </a>
        </div>
        <p class="child">
          <xsl:value-of select ="."/>
        </p>
      </xsl:for-each>
      <h4>Return Value</h4>
      <p class="child">
        <xsl:value-of select ="ReturnValue"/>
      </p>
      <h4>
        <xsl:value-of select="name(Remarks)"/>
      </h4>
      <xsl:for-each select="Remarks/child::node()">
        <xsl:choose>
          <xsl:when test="name(.) = 'Para'">
            <p class="child">
              <xsl:value-of select ="."/>
            </p>
          </xsl:when>
          <xsl:otherwise>
            <ul class="child">
              <xsl:for-each select="ListItem">
                <li>
                  <xsl:value-of select ="."/>
                </li>
              </xsl:for-each>
            </ul>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:for-each>
      <h4>
        <xsl:value-of select="name(Examples)"/>
      </h4>
      <xsl:for-each select="Examples/Example">
        <div class="syntax">
          <div class="language">
            <xsl:value-of select ="@language"/>
          </div>
          <div class="data">
            <xsl:for-each select="tokenize(., '\n')">
              <div>
                <xsl:value-of select="."/>
              </div>
            </xsl:for-each>
          </div>
        </div>
      </xsl:for-each>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>