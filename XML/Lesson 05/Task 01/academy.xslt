<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="training">
    <html>
      <head>
        <meta charset="utf-8"/>
        <title>Академия</title>
        <style>
          body { min-width: 500px; }
          table { border-collapse: collapse; margin: 50px 0 50px 0; }
          caption { font-size: 20px; font-weight: bold; }
          th { border: 1px solid black; font-size: 18px; }
          td { border: 1px solid black; }
          .student-data { font-weight: bold; text-align: center; }
        </style>
      </head>
      <body>
        <xsl:apply-templates select="groups"/>
        <xsl:apply-templates select="subjects"/>
        <xsl:apply-templates select="teachers"/>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="groups">
    <table>
      <caption>Группы</caption>
      <thead>
        <tr>
          <th>Название группы</th>
          <th>Специализация</th>
          <th colspan="3">Студенты</th>
        </tr>
      </thead>
      <tbody>
        <xsl:for-each select="group">
          <tr>
            <td rowspan="{ count(student) + 1 }"><xsl:value-of select="@name"/></td>
            <td rowspan="{ count(student) + 1 }"><xsl:value-of select="@specialization"/></td>
            <td class="student-data">ФИО</td>
            <td class="student-data">Адрес</td>
            <td class="student-data">Размер стипендии (грн.)</td>
          </tr>
          <xsl:for-each select="student">
            <xsl:sort select="name/@last-name"/>
            <tr>
              <td><xsl:value-of select="concat(name/@last-name, ' ', name/@first-name, ' ', name/@patronymic)"/></td>
              <td><xsl:value-of select="concat(address/@country, ', г. ', address/@city, ', ', address/@street, ', ', address/@house, ', тел.: ', address/@telephone, ', e-mail: ', address/@e-mail)"/></td>
              <td><xsl:value-of select="scholarship"/></td>
            </tr>
          </xsl:for-each>
        </xsl:for-each>
      </tbody>
    </table>		
  </xsl:template>
  <xsl:template match="subjects">
    <table>
      <caption>Предметы</caption>
      <thead>
        <tr>
          <th>Название предмета</th>
          <th>План курса</th>
        </tr>
      </thead>
      <tbody>
        <xsl:for-each select="subject">
          <tr>
            <td><xsl:value-of select="name"/></td>
            <td><xsl:value-of select="plan"/></td>
          </tr>
        </xsl:for-each>
      </tbody>
    </table>		
  </xsl:template>
  <xsl:template match="teachers">
    <table>
      <caption>Преподаватели</caption>
      <thead>
        <tr>
          <th>ФИО</th>
          <th>Читаемые предметы</th>
          <th>Количество групп</th>
        </tr>
      </thead>
      <tbody>
        <xsl:for-each select="teacher">
          <xsl:sort select="name/@last-name"/>
          <tr>
            <td rowspan="{ count(subjects/subject) }"><xsl:value-of select="concat(name/@last-name, ' ', name/@first-name, ' ', name/@patronymic)"/></td>
            <td><xsl:value-of select="subjects/subject[position() = 1]"/></td>
            <td rowspan="{ count(subjects/subject) }"><xsl:value-of select="groups-count"/></td>						
          </tr>
          <xsl:for-each select="subjects/subject[position() != 1]">
            <tr>
              <td><xsl:value-of select="."/></td>
            </tr>
          </xsl:for-each>
        </xsl:for-each>
      </tbody>
    </table>
  </xsl:template>
</xsl:stylesheet>